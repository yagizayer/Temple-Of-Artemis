using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public partial class DialogManagement : MonoBehaviour
{

    #region TalkingScreen Variables
    public GameObject TalkingScreen;
    [SerializeField] private Text Context;
    [SerializeField] private RawImage LeftSprite;
    [SerializeField] private RawImage RightSprite;

    [Header("Character Textures")]
    [SerializeField] private Texture PlayerTexture;
    [SerializeField] private Texture ProfTexture;
    [SerializeField] private Texture ArtTexture;
    [SerializeField] private Texture MinerTexture;
    [SerializeField] private Texture BlankTexture;

    private bool _currentlyWriting = false;
    private bool _breakLoop = false;
    private string _currentLine = "";



    private ConversationType _conversationType;
    private QuestConversation _currentConversation;
    private QuestObject _currentObject;
    private string _objectsTargetNpc;
    private bool _reactedToObject = false;
    #endregion

    #region Storyline Variables
    private Dictionary<PhaseNames, Phase> _storyline = new Dictionary<PhaseNames, Phase>();
    public Dictionary<PhaseNames, Phase> Storyline { get => _storyline; set => _storyline = value; }
    #endregion

    #region OtherVariables
    [Header("Others")]
    [SerializeField] private List<NpcMovement> npcMovements;

    private TemplesAndQuestObjectsManagement TAQM;
    #endregion


    [SerializeField] private SoundManagement SoundManager;
    void Start()
    {
        if (SoundManager == null) SoundManager = FindObjectOfType<SoundManagement>();
        TAQM = FindObjectOfType<TemplesAndQuestObjectsManagement>();
        SetStoryline();

        StartCoroutine(RotaredStart(.5f));
    }
    private IEnumerator RotaredStart(float waitForSec)
    {
        yield return new WaitForSecondsRealtime(waitForSec);
        InteractWithNpc();
    }
    void SetStoryline()
    {
        #region EarlyPhase

        Phase earlyPhase = new Phase();

        Quest tutorial = new Quest();
        List<QuestConversation> tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Jeolog,new List<string>(){
                "How much further do we have to walk? The sun began to faint on me."
            }),
            new QuestConversation(Npcs.SanatTarihiUzmani,new List<string>(){
                "Stop whining little baby locals said Ancient ruins are out there somewhere."
            }),
            new QuestConversation(Npcs.Jeolog,new List<string>(){
                "We will probably have come this far for just a few old pottery again."
            }),
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "Stop swaying, look how beautiful it is, green everywhere, enjoy a little nature.",
                "What do you think, Jones? Do you think we will encounter a sight worth coming this far?"
            }),
            new QuestConversation(Npcs.Player,new List<string>(){
                "Even if we can't find the ruins that the locals talk about, this natural environment is worth coming here."
            }),
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "I think you're right, the weather here is very nice. But it still wouldn't hurt to find some relics from ancient times."
            }),
        };
        tutorial.QuestConversations = tempConversationList;

        Quest findAncientColumns = new Quest();
        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                    "Wow! What did you find, Jones?"
                }),
            new QuestConversation(Npcs.Jeolog,new List<string>(){
                    "I think there's more than pottery here.",
                    "According to my measurements, these columns are at least 2000 years old."
                }),
            new QuestConversation(Npcs.SanatTarihiUzmani,new List<string>(){
                    "The glyph on them are very interesting, I have never seen such motifs before."
                }),
            new QuestConversation(Npcs.Profesor,new List<string>(){
                    "Are there any more around?"
                })
        };
        findAncientColumns.QuestConversations = tempConversationList;


        Quest talkToProfessor = new Quest();
        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "Can you believe that this structure has been hidden for so many years?",
                "If we look at what the geologist said, we are looking at the ruins of a temple that is at least 2000 years old.",
                "I wonder who did it when, let's take a look around; maybe we'll come across some items that might be clues."
            }),
        };
        talkToProfessor.QuestConversations = tempConversationList;

        Quest gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "PaintingOfAmazons",
                new QuestObject(
                    "Painting Of Amazons",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        GlobalVariables.PlayerName + "! Where did you get this painting, it's been virtually unharmed all this time.",
                        "Hmmm. The Amazons were the only civilizations to have lived in ancient times that made such durable paintings. ",
                        "I think they must have made this painting as well."
                    }
                )
            },
            {
                "PaintingOfTreeOfLife",
                new QuestObject(
                    "Painting Of Tree Of Life",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Wow look at this beauty. I think this tree is the Tree of Life, which has been the subject of old poems.",
                        "When the Amazons migrated here from Ionia in 300 BC, they brought such works and stories with them."
                    }
                )
            },
            {
                "BrokenSculpture",
                new QuestObject(
                    "Broken Sculpture",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Wow. Such a well preserved statue.",
                        "Let's see how old are you... ",
                        GlobalVariables.PlayerName + ". This little friend of ours is almost the professor's age... unless you count that it's 40 times as old!",
                        "This thing has been standing here for 2200 years without breaking, intact."
                    }
                )
            },
            {
                "AmberNecklace",
                new QuestObject(
                    "Amber Necklace",
                    Npcs.Jeolog,
                    new List<string>(){
                        "What is that thing in your hand, Jones?",
                        "Let's see... It looks like it's a pendant.",
                        "Look, there are holes on both sides. It is most likely an artifact made for the Goddess to which this temple is dedicated.",
                        "Such necklaces were very valuable in their time. I'm surprised no one has stole it all this time."
                    }
                )
            },
            {
                "FigureOfTreeOfLife",
                new QuestObject(
                    "Glyph Of Tree Of Life",
                    Npcs.Profesor,
                    new List<string>(){
                        "Yes... It's very interesting...",
                        "You have found a glyph depicting the ancient belief in the Tree of Life, Jones.",
                        "It was such a tree that it connects Heaven and Hell, All life emerges from this tree and returns to this tree again. ",
                        "Many religions, philosophies and mythologies speak of this tree. I think this is one of the first works on the Tree of Life."
                    }
                )
            },{
                "0",
                new QuestObject(
                    "Painting Of Amazons",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        GlobalVariables.PlayerName + "! Where did you get this painting, it's been virtually unharmed all this time.",
                        "Hmmm. The Amazons were the only civilizations to have lived in ancient times that made such durable paintings. ",
                        "I think they must have made this painting as well."
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Painting Of Tree Of Life",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Wow look at this beauty. I think this tree is the Tree of Life, which has been the subject of old poems.",
                        "When the Amazons migrated here from Ionia in 300 BC, they brought such works and stories with them."
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Broken Sculpture",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Wow. Such a well preserved statue.",
                        "Let's see how old are you... ",
                        GlobalVariables.PlayerName + ". This little friend of ours is almost the professor's age... unless you count that it's 40 times as old!",
                        "This thing has been standing here for 2200 years without breaking, intact."
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Amber Necklace",
                    Npcs.Jeolog,
                    new List<string>(){
                        "What is that thing in your hand, Jones?",
                        "Let's see... It looks like it's a pendant.",
                        "Look, there are holes on both sides. It is most likely an artifact made for the Goddess to which this temple is dedicated.",
                        "Such necklaces were very valuable in their time. I'm surprised no one has stole it all this time."
                    }
                )
            },
            {
                "4",
                new QuestObject(
                    "Glyph Of Tree Of Life",
                    Npcs.Profesor,
                    new List<string>(){
                        "Yes... It's very interesting...",
                        "You have found a glyph depicting the ancient belief in the Tree of Life, Jones.",
                        "It was such a tree that it connects Heaven and Hell, All life emerges from this tree and returns to this tree again. ",
                        "Many religions, philosophies and mythologies speak of this tree. I think this is one of the first works on the Tree of Life."
                    }
                )
            }
        });

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "Can you believe that this structure has been hidden for so many years?",
                "If we look at what the geologist said, we are looking at the ruins of a temple that is at least 2000 years old.",
                "I wonder who did it when, let's take a look around; maybe we'll come across some items that might be clues."
            })
        };
        gatherInformationAroundTemple.QuestConversations = tempConversationList;

        earlyPhase.Quests.AddRange<QuestNames, Quest>(new Dictionary<QuestNames, Quest>(){
            {QuestNames.Tutorial,tutorial},
            {QuestNames.FindAncientColumns,findAncientColumns},
            {QuestNames.TalkToProfessor,talkToProfessor},
            {QuestNames.GatherInformationAroundTemple,gatherInformationAroundTemple}
        });

        earlyPhase.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                GlobalVariables.PlayerName + " when you gather the clues you have gathered, it becomes clear what this temple was, when and by whom it was built."
            },
            new TempleInfo(
                "Lost Temple of Artemis",
                "Between 3300 BC ~ 1200 BC ",
                new List<string>(){
                    "Architect: Amazons",
                    "Reason for Construction : When God Dionysus and his followers declared war on the Amazons, they built this temple to take shelter in Artemis, the Goddess of Hunting and Fertility.",
                    "Cause of Destruction: A huge flood that occurred as a result of a storm in the Aegean Sea in 700 BC"
                }
            ),
            new List<string>()
            {
                "So this is the lost temple of artemis mentioned in the legends.",
                "Well, then what happened? I mean, no one has come to this temple since the 7th century BC?",
                "I think that can't be true, we have to look for clues! We should learn the history of this place!"
            }
        );

        Storyline.Add(PhaseNames.EarlyPhase, earlyPhase);

        #endregion EarlyPhase

        #region FirstTemple

        Phase firstTemple = new Phase();

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "So this is the lost temple of artemis mentioned in the legends.",
                "Well, then what happened? I mean, no one has come to this temple since the 7th century BC?",
                "I think that can't be true, we have to look for clues! We should learn the history of this place!"
            })
        };

        gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "Sculpture",
                new QuestObject(
                    "Sculpture",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "So you found another statue, Jones. ",
                        "It was very costly to make such statues and leave them in temples back then.",
                        "This little kid's family must be quite wealthy. "
                    }
                )
            },
            {
                "GoldCoins",
                new QuestObject(
                    "Gold Coins",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah! Small stones and rocks come to me as always. ",
                        "It's like why didn't I study art history... Wait a minute, this is not a normal stone!",
                        "Gold! This is Gold! And It is not an ordinary gold coin either. ",
                        "This is gold even older than the oldest known gold coins ever!",
                        "It's gold from the 6th century BC, Jones!"
                    }
                )
            },
            {
                "BurnMarks",
                new QuestObject(
                    "Burn Marks",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Yes, I saw some burn marks walking around. Although they were very old burn marks, they had not even faded.",
                        "It must have been a huge fire, since the marks penetrate even the marble."
                    }
                )
            },
            {
                "PieceOfFineClothing",
                new QuestObject(
                    "Piece Of Fine Clothing From a King",
                    Npcs.Profesor,
                    new List<string>(){
                        GlobalVariables.PlayerName + " Jones, This piece of cloth you found looks like it belonged to an outfit made from very expensive fabrics by the finest tailors of the time.",
                        "It probably belonged to a king or a very wealthy merchant.",
                        "Not surprising when you think about it. Such temples were rare in their time and attracted wealthy people from all over the world.",
                        "The rich people who came to these temples would donate and pray, and those in need would gather here and accept help from the rich people."
                    }
                )
            },{
                "0",
                new QuestObject(
                    "Sculpture",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "So you found another statue, Jones. ",
                        "It was very costly to make such statues and leave them in temples back then.",
                        "This little kid's family must be quite wealthy. "
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Gold Coins",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah! Small stones and rocks come to me as always. ",
                        "It's like why didn't I study art history... Wait a minute, this is not a normal stone!",
                        "Gold! This is Gold! And It is not an ordinary gold coin either. ",
                        "This is gold even older than the oldest known gold coins ever!",
                        "It's gold from the 6th century BC, Jones!"
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Burn Marks",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Yes, I saw some burn marks walking around. Although they were very old burn marks, they had not even faded.",
                        "It must have been a huge fire, since the marks penetrate even the marble."
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Piece Of Fine Clothing From a King",
                    Npcs.Profesor,
                    new List<string>(){
                        GlobalVariables.PlayerName + " Jones, This piece of cloth you found looks like it belonged to an outfit made from very expensive fabrics by the finest tailors of the time.",
                        "It probably belonged to a king or a very wealthy merchant.",
                        "Not surprising when you think about it. Such temples were rare in their time and attracted wealthy people from all over the world.",
                        "The rich people who came to these temples would donate and pray, and those in need would gather here and accept help from the rich people."
                    }
                )
            }
        });
        gatherInformationAroundTemple.QuestConversations = tempConversationList;

        firstTemple.Quests.AddRange<QuestNames, Quest>(new Dictionary<QuestNames, Quest>(){
            {QuestNames.GatherInformationAroundTemple,gatherInformationAroundTemple}
        });

        firstTemple.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                GlobalVariables.PlayerName + " when we put together the clues you've gathered, it explains what happened to the Ancient Temple of Artemis and what happened there."
            },
            new TempleInfo(
                "The Temple of Artemis",
                "550 BC",
                new List<string>(){
                    "Architect: Chersiphron and his son Metagenes(Vitruvius), funded by King Croesus.",
                    "Usage: This temple, which has become a touristic structure frequently visited by Kings and Merchants, has also been a safe haven for the helpless or those fleeing persecution.",
                    "Destruction: In 356 BC, a madman named Herostratos was incited by malicious people in the local community with the words \"The name of the person who destroyed this temple is mentioned in all history books\" and incited the arson. ",
                    "Today, the phrase \"herostratic fame\" is used to mean \"to be famous at any cost\".",
                    "In the legends, it is connected why Artemis, the Goddess of Fertility, was not here to protect her temple during this arson, because she went to help the birth of a very important person."
                }
            ),
            new List<string>()
            {
                "So the \"Herostratic fame\" came from the name of the person who started this arson.",
                "What happened next? Didn't the kings, the merchants, the people who made this place their home, never come back after it was destroyed?",
                "We should investigate further. The story cannot end here!"
            }
        );

        Storyline.Add(PhaseNames.FirstTemple, firstTemple);

        #endregion FirstTemple

        #region LastTemple

        Phase lastTemple = new Phase();

        gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "PaintingOfAlexanderTheGreat",
                new QuestObject(
                    "Painting Of Alexander The Great",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Yes, I know this person. Alexander the Great, whose name is frequently heard by many artists and historians, who ruled almost the whole of the Asian continent and parts of Africa and Europe in his time.",
                        "I've never actually seen this painting, but if we look at the date it was made, we can definitely say that it was made while Alexander the Great was still alive."
                    }
                )
            },
            {
                "PaintingOfArtemis",
                new QuestObject(
                    "Painting of Artemis, Goddess of Fertility, assisting a birth",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "What is this? It looks like it was made in an art generation I've never seen before.",
                        "The most prominent person in the painting is the woman in the middle giving birth and another woman who seems to be helping her.",
                        "I have no idea what it means."
                    }
                )
            },
            {
                "NyxFigure",
                new QuestObject(
                    "Nyx Figure",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah, another statue. ",
                        "It looks like there's something like a signature on the bottom.",
                        "This? This is the Nyx figure of Rhoecus! ",
                        "What we are holding now is the masterpiece of the most valuable artist of his time.",
                        "I thought we couldn't find anything more interesting after the gold coin you found earlier.",
                        "I was mistaken. And what a mistake. This statue is even more valuable than gold!"
                    }
                )
            },
            {
                "TalePiece1",
                new QuestObject(
                    "Legend Fragment 1 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            },
            {
                "TalePiece2",
                new QuestObject(
                    "Legend Fragment 2 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            },
            {
                "TalePiece3",
                new QuestObject(
                    "Legend Fragment 3 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            },{
                "0",
                new QuestObject(
                    "Painting Of Alexander The Great",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Yes, I know this person. Alexander the Great, whose name is frequently heard by many artists and historians, who ruled almost the whole of the Asian continent and parts of Africa and Europe in his time.",
                        "I've never actually seen this painting, but if we look at the date it was made, we can definitely say that it was made while Alexander the Great was still alive."
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Painting of Artemis, Goddess of Fertility, assisting a birth",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "What is this? It looks like it was made in an art generation I've never seen before.",
                        "The most prominent person in the painting is the woman in the middle giving birth and another woman who seems to be helping her.",
                        "I have no idea what it means."
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Nyx Figure",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah, another statue. ",
                        "It looks like there's something like a signature on the bottom.",
                        "This? This is the Nyx figure of Rhoecus! ",
                        "What we are holding now is the masterpiece of the most valuable artist of his time.",
                        "I thought we couldn't find anything more interesting after the gold coin you found earlier.",
                        "I was mistaken. And what a mistake. This statue is even more valuable than gold!"
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Legend Fragment 1 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            },
            {
                "4",
                new QuestObject(
                    "Legend Fragment 2 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            },
            {
                "5",
                new QuestObject(
                    "Legend Fragment 3 (Scroll)",
                    Npcs.Profesor,
                    new List<string>(){
                        "What is that? It looks like a piece of parchment.",
                        "Translating ancient Greek texts can take some time. In the meantime, you go and see if there are any more Parchment pieces."
                    }
                )
            }
        });

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "So the \"Herostratic fame\" came from the name of the person who started this arson.",
                "What happened next? Didn't the kings, the merchants, the people who made this place their home, never come back after it was destroyed?",
                "We should investigate further. The story cannot end here!"
            })
        };
        gatherInformationAroundTemple.QuestConversations = tempConversationList;

        lastTemple.Quests.AddRange<QuestNames, Quest>(new Dictionary<QuestNames, Quest>(){
            {QuestNames.GatherInformationAroundTemple,gatherInformationAroundTemple}
        });

        lastTemple.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                GlobalVariables.PlayerName + " I've put together and translated the pieces of Parchment you've collected. And on the scrolls was written a magnificent legend."
            },
            new TempleInfo(
                "The Temple of Artemis",
                "323 BC",
                new List<string>(){
                    "Architect: Endoeus (and many other architects) funded by the Ephesians.",
                    "\tThe Story of Alexander the Great and the Temple of Artemis",
                    "While Alexander the Great was resting in his tent, exhausted from the war, a conversation outside caught his attention.",
                    "Soldiers talk about a temple. It is a temple that was established in a city close to the area they fought but was destroyed many years ago.",
                    "When Alexander the Great asked what he knew about this temple, the surprised soldier said: \"The temple of Artemis, the goddess of fertility and hunting. But Sir, it was destroyed years ago.\" ",
                    "After this fact, Alexander the Great, who changed his course and headed towards the temple, knows very well what he will encounter. This is the Temple of the Goddess Artemis, who is also the Goddess of Fertility.",
                    "When they arrived at the temple, Alexander the Great, who encountered a pile of ruined marble, talked to the rulers of the Ephesians, the people of the city where the temple was built, and asked them for permission to repair the temple.",
                    "Because the he thinks that Goddess Artemis helped her mother to give birth during the arson that caused her to be unable to protect her temple.",
                    "The only wish of the Ephesians is that when the construction of the temple is completed, his name will be included in this temple.",
                    "The rulers of the people of Ephesus did not like this request of Alexander the Great, but they hesitated to refuse his request, considering the army he brought with him.",
                    "One of the rulers finally stood before Alexander the Great and said: \"A god should not build another god's temple.\"",
                    "Satisfied with this word of the ruler, Alexander the Great was pleased with the praise and left the city of Ephesus without repairing the temple.",
                    "In the intervening time, while Alexander the Great was fighting the Persian Empire in Anatolia and beyond, the people of the City of Ephesus slowly started to repair the temple.",
                    "It will be almost the size of a stadium (137m x 69m x 18m), even larger than the previous two temples. More than 127 columns will surround the Cella, with a gigantic Artemis Statue in the middle. As a matter of fact, it will take years for them to finish this magnificent structure. ",
                    "\tForgetting the Goddess Artemis and the destruction of the Temple",
                    "After the temple was repaired, it stood for about 600 years. In the Crusades, which took place with the spread of Christianity, the Ephesians were worried that the temple would be stained by the Christians, but they could not do anything.",
                    "When the Altar of Artemis was shattered during a Christian exorcism ceremony held in the temple in the 2nd century BC, most of the Ephesians there escaped, but some accepted to become Christians.",
                    "Thus, the Temple of Artemis ceased to be a shelter for those in need, a tourist destination for big merchants, and began to sink into the dusty pages of history."
                }
            ),
            new List<string>()
            {
            }
        );

        Storyline.Add(PhaseNames.LastTemple, lastTemple);

        #endregion LastTemple

        #region EndTemple

        Phase endTemple = new Phase();

        gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "PlaceHolder",
                new QuestObject(
                    "Painting Of Alexander The Great",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Yes, I know this person. Alexander the Great, whose name is frequently heard by many artists and historians, who ruled almost the whole of the Asian continent and parts of Africa and Europe in his time.",
                        "I've never actually seen this painting, but if we look at the date it was made, we can definitely say that it was made while Alexander the Great was still alive."
                    }
                )
            },

        });

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "So the \"Herostratic fame\" came from the name of the person who started this arson.",
                "What happened next? Didn't the kings, the merchants, the people who made this place their home, never come back after it was destroyed?",
                "We should investigate further. The story cannot end here!"
            })
        };
        gatherInformationAroundTemple.QuestConversations = tempConversationList;

        endTemple.Quests.AddRange<QuestNames, Quest>(new Dictionary<QuestNames, Quest>(){
            {QuestNames.GatherInformationAroundTemple,gatherInformationAroundTemple}
        });

        endTemple.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                GlobalVariables.PlayerName + " I've put together and translated the pieces of Parchment you've collected. And on the scrolls was written a magnificent legend."
            },
            new TempleInfo(
                "",
                "",
                new List<string>()
                {
                }
            ),
            new List<string>()
            {
            }
        );

        Storyline.Add(PhaseNames.EndPhase, endTemple);

        #endregion EndTemple

    }

    public void InteractWithQuestObject(Npcs targetNpc)
    {
        _reactedToObject = false;
        _conversationType = ConversationType.ObjectReaction;
        RightSprite.texture = BlankTexture;
        TalkingScreen.SetActive(true);
        _objectsTargetNpc = GlobalVariables.NpcNames[targetNpc];
        NextLineOrExit();

    }

    public void InteractWithNpc(Npcs npcName = Npcs.Player, QuestObject_SO questObject = null, UnityAction callback = null)
    {
        _currentConversation = null;
        _currentObject = null;
        if (questObject != null && npcName != Npcs.Player)
        {
            Dictionary<string, QuestObject> currentQuestObjects = Storyline[QuestTracker.CurrentPhaseName].Quests[QuestTracker.CurrentQuestName].QuestObjects;
            foreach (KeyValuePair<string, QuestObject> item in currentQuestObjects)
            {
                if (item.Key == questObject.KeyName && item.Value.TargetNpc == npcName)
                {
                    // remove Item from canvas
                    callback();
                    SetupTalkingScreen(item.Value);
                    QuestTracker.questObjectTracker[(QuestTracker.CurrentPhaseName, item.Value.Name)] = true;
                }
            }
        }
        else
        {
            _currentConversation = Storyline[QuestTracker.CurrentPhaseName].Quests[QuestTracker.CurrentQuestName].CurrentConvarsation;
            SetupTalkingScreen(_currentConversation);
        }
    }
    public void SetupTalkingScreen(QuestObject questObject)
    {
        _conversationType = ConversationType.ObjectConversation;
        _currentObject = questObject;
        if (questObject.TargetNpc == Npcs.Profesor) RightSprite.texture = ProfTexture;
        if (questObject.TargetNpc == Npcs.SanatTarihiUzmani) RightSprite.texture = ArtTexture;
        if (questObject.TargetNpc == Npcs.Jeolog) RightSprite.texture = MinerTexture;
        TalkingScreen.SetActive(true);
        NextLineOrExit();
    }
    private void SetupTalkingScreen(QuestConversation questConversation)
    {
        _conversationType = ConversationType.QuestConversation;
        _currentConversation = questConversation;
        if (questConversation.Speaker == Npcs.Profesor) RightSprite.texture = ProfTexture;
        if (questConversation.Speaker == Npcs.SanatTarihiUzmani) RightSprite.texture = ArtTexture;
        if (questConversation.Speaker == Npcs.Jeolog) RightSprite.texture = MinerTexture;
        TalkingScreen.SetActive(true);
        NextLineOrExit();
    }
    public void NextLineOrExit()
    {
        if (!_currentlyWriting)
        {
            _currentLine = GetNextLine();
            if (_currentLine == null)
            {
                SoundManager.StopSound(SoundManager.EffectSounds[EffectSound.Npc_Prof]);
                SoundManager.StopSound(SoundManager.EffectSounds[EffectSound.Npc_Art]);
                SoundManager.StopSound(SoundManager.EffectSounds[EffectSound.Npc_Miner]);
                SoundManager.StopSound(SoundManager.EffectSounds[EffectSound.Player]);

                TalkingScreen.SetActive(false);
                QuestTracker.NextQuest();
                if (QuestTracker.CurrentQuestName == QuestNames.TalkToProfessor)
                {
                    foreach (NpcMovement item in npcMovements)
                    {
                        item.MoveNextPosition();
                    }
                    TAQM.ShowCurrentTemple();
                }
            }
            else
            {
                if (_currentConversation != null && _currentConversation.Speaker == Npcs.Profesor)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Prof]);
                if (_currentConversation != null && _currentConversation.Speaker == Npcs.SanatTarihiUzmani)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Art]);
                if (_currentConversation != null && _currentConversation.Speaker == Npcs.Jeolog)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Miner]);
                if (_currentConversation != null && _currentConversation.Speaker == Npcs.Player)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Player]);

                if (_currentObject != null && _currentObject.TargetNpc == Npcs.Profesor)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Prof]);
                if (_currentObject != null && _currentObject.TargetNpc == Npcs.SanatTarihiUzmani)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Art]);
                if (_currentObject != null && _currentObject.TargetNpc == Npcs.Jeolog)
                    SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Npc_Miner]);


                _breakLoop = false;
                StartCoroutine(CreateEffect(Context, _currentLine));
            }
        }
        else
        {
            _breakLoop = true;
            StopCoroutine("CreateEffect");
            Context.text = _currentLine;
            _currentlyWriting = false;
        }
    }
    private string GetNextLine()
    {
        string result = "";
        if (_conversationType == ConversationType.ObjectReaction)
        {
            if (_reactedToObject) return null;
            _reactedToObject = true;
            result = "Hmm... Bu ilginç Bir eşyaya benziyor. Belki de " + _objectsTargetNpc + " görse iyi olur";
            SoundManager.StartSound(SoundManager.EffectSounds[EffectSound.Player]);

        }
        if (_conversationType == ConversationType.ObjectConversation)
        {
            result = _currentObject.NextLine;
        }
        if (_conversationType == ConversationType.QuestConversation)
        {
            result = _currentConversation.NextLine;
            if (result == null)
            {
                Quest currentQuest = Storyline[QuestTracker.CurrentPhaseName].Quests[QuestTracker.CurrentQuestName];
                if (currentQuest.QuestConversations.IndexOf(_currentConversation) < currentQuest.QuestConversations.Count - 1)
                {
                    _currentConversation = currentQuest.NextConversation;
                    if (_currentConversation.Speaker == Npcs.Profesor) RightSprite.texture = ProfTexture;
                    if (_currentConversation.Speaker == Npcs.SanatTarihiUzmani) RightSprite.texture = ArtTexture;
                    if (_currentConversation.Speaker == Npcs.Jeolog) RightSprite.texture = MinerTexture;
                    result = _currentConversation.NextLine;

                }
            }
        }


        return result;
    }

    // typewriting effect
    IEnumerator CreateEffect(Text context, string text)
    {
        context.text = "";
        int characterCounter = 0;
        while (characterCounter < text.Length && !_breakLoop)
        {
            _currentlyWriting = true;
            context.text += text[characterCounter++].ToString();
            yield return null;
        }
        _currentlyWriting = false;

    }
}
