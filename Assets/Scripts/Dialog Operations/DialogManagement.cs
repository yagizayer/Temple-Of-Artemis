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
                "Between BC 3300 ~ BC 1200",
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
                "Demek efsanelerde bahsedilen kayıp Artemis Tapınağı burasıymış.",
                "Peki ama sonra ne oldu acaba. Yani milattan önce 7. yüzyıldan bu yana hiç kimse gelmedi mi acaba bu tapınağa?",
                "Bence bu doğru olamaz ipuçları aramalıyız! Buranın tarihini öğrenmeliyiz!"
            })
        };

        gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "Sculpture",
                new QuestObject(
                    "Heykel",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Demek bir heykel daha buldun Jones. ",
                        "Bu tür heykellerinin yapılması ve tapınaklara bırakılması çok pahalıya mal olurmuş o zamanlar.",
                        "Bu küçük çocuğun ailesi oldukça varlıklı olmalı. "
                    }
                )
            },
            {
                "GoldCoins",
                new QuestObject(
                    "Altın Sikkeler",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah! Her zamanki gibi küçük taşlar kayalar bana gelir. ",
                        "Neden sanat tarihi okumadım ki sanki... Bir saniye, bu normal bir taş değil!",
                        "Altın! Bu Altın! Hemde sıradan bir altın para değil. ",
                        "Şimdiye kadar bilinen en eski altın paralardan bile eski bir altın bu!",
                        "Milattan önce 6. yüzyıldan kalma bir altın bu Jones!"
                    }
                )
            },
            {
                "BurnMarks",
                new QuestObject(
                    "Yanık izleri",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Evet etrafta dolaşırken bazı yanık izleri görmüştüm. Çok eski yanık izleri olmalarına rağmen solmamışlardı bile.",
                        "Mermerin bile içine işleyecek kadar güçlü izler oluşturduğuna göre devasa bir yangın olmalı."
                    }
                )
            },
            {
                "PieceOfFineClothing",
                new QuestObject(
                    "Kralın birinden bir parça kumaş",
                    Npcs.Profesor,
                    new List<string>(){
                        GlobalVariables.PlayerName + " Bu bulduğun kumaş parçası döneminin en kaliteli terzileri tarafından çok pahalı kumaşlardan yapılmış bir kıyafete ait gibi görünüyor.",
                        "Muhtemelen bir krala ya da çok zengin bir tüccara aitti bu kıyafet.",
                        "Düşünce şaşırtıcı değil. Zamanında bu tür tapınaklar çok az bulunurdu ve dünyanın dört bir yanından zenginleri kendisine çekerdi.",
                        "Bu tapınaklara gelen zenginler başıta bulunup dua ederler ve ihtiyacı olanlar da buralarda toplanarak gelen zenginlerden yardım kabul ederlerdi."
                    }
                )
            },
            {
                "0",
                new QuestObject(
                    "Heykel",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Demek bir heykel daha buldun Jones. ",
                        "Bu tür heykellerinin yapılması ve tapınaklara bırakılması çok pahalıya mal olurmuş o zamanlar.",
                        "Bu küçük çocuğun ailesi oldukça varlıklı olmalı. "
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Altın Sikkeler",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Ah. her zamanki gibi küçük taşlar kayalar bana gelir. ",
                        "Neden sanat tarihi okumadım ki sank... Bir saniye bu normal bir taş değil.",
                        "Altın! Bu Altın! Hemde sıradan bir altın para değil. ",
                        "Şimdiye kadar bilinen en eski altın paralardan bile eski bir altın bu!",
                        "Milattan önce 6. yüzyıldan kalma bir altın bu Jones!"
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Yanık izleri",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Evet etrafta dolaşırken bazı yanık izleri görmüştüm. Çok eski yanık izleri olmalarına rağmen solmamışlardı bile.",
                        "Mermerin bile içine işleyecek kadar güçlü izler oluşturduğuna göre devasa bir yangın olmalı."
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Kralın birinden Bir parça kumaş",
                    Npcs.Profesor,
                    new List<string>(){
                        GlobalVariables.PlayerName + " bu bulduğun kumaş parçası döneminin en kaliteli terzileri tarafından çok pahalı kumaşlardan yapılmış bir kıyafete ait gibi görünüyor.",
                        "Muhtemelen bir krala yada çok zengin bir tüccara aitti bu kıyafet.",
                        "Düşünce şaşırtıcı değil. Zamanında bu tür tapınaklar çok az bulunurdu ve dünyanın dört bir yanından zenginleri kendisine çekerdi.",
                        "Bu tapınaklara gelen zenginler başıta bulunup dua ederler ve ihtiyacı olanlar da buralarda toplanarak gelen zenginlerden yardım kabul ederlerdi."
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
                GlobalVariables.PlayerName + " topladığın ipuçlarını bir araya geldiğinde Antik Artemis Tapınağına ne olduğu ve burada neler yaşandığı biraz daha açıklanıyor."
            },
            new TempleInfo(
                "Artemis Tapınağı",
                "MÖ 550",
                new List<string>(){
                    "Mimar : Chersiphron ve onun oğlu Metagenes(Vitruvius), Kral Croesus tarafından fonlandı.",
                    "Kullanımı : Krallar ve Tacirler tarafından sıkça ziyaret edilen turistik bir yapı haline gelen bu tapınak, aciz durumda olan veya zulümden kaçanlar için de güvenli bir sığınak oldu. ",
                    "Yıkımı : MÖ 356'da Herostratos adındaki bir meczup yerel halktaki kötü niyetli kişiler tarafından \"Bu tapınağı yıkan kişinin adı bütün tarih kitaplarında geçer\" söylemleri ile kışkırtılarak yangına teşvik edilmiştir. ",
                    "Günümüzde \"Herostratik ün\" deyimi \"Ne pahasına olursa olsun ünlenmek\" manasında kullanılmaktadır. ",
                    "Efsanelerde bu yangın sırasında Bereket Tanrıçası Artemis'in neden tapınağını korumak için burada olmadığı, çok önemli bir kişinin doğumuna yardım etmek için gittiğinden burada olmamasına bağlanmaktadır."
                }
            ),
            new List<string>()
            {
                "Demek \"Herostratik ün\" bu yangını başlatan kişinin adından dolayı çıkmış. ",
                "Sonra ne oldu acaba? Yani milattan önce 356 yılında Büyük iskender doğduktan sonra buraya hiç yolu düştü mü?",
                "Peki ya yerel halk? Krallar, tüccarlar, burayı yuva edinen kişiler yıkıldıktan sonra bir daha geri dönmediler mi?",
                "Daha fazla araştırmalıyız. Hikaye burada bitemez!"
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
                    "Büyük İskender'in tablosu",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Evet bu kişiyi tanıyorum. Kendisi zamanında asya kıtasının neredeyse tamamını ve Afrika ve Avrupanın da bazı bölgelerini yönetmiş olan pek çok sanatçı ve tarihçi tarafından adı sıkça duyulmuş olan Büyük İskender.",
                        "Tam olarak bu tablosunu hiç görmemiştim ama yapıldığı tarihe bakacak olursak kesinlikle Büyük iskender hala hayattayken yapıldığını söyleyebiliriz."
                    }
                )
            },
            {
                "PaintingOfArtemis",
                new QuestObject(
                    "Bereket Tanrıçası Artemisin, bir doğuma yardım edişinin tablosu",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Bu da ne böyle? Daha önce hiç görmediğim bir sanat jenerasyonunda yapılmışa benziyor.",
                        "Tabloda en belirgin olan kişi ortadaki doğum yapan kadın ve ona yardımcı oluyor gibi görünen başka bir kadın.",
                        "Ne anlama geldiğini hiç bilemiyorum."
                    }
                )
            },
            {
                "NyxFigure",
                new QuestObject(
                    "Nyx Figürü",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Hah bir heykel daha. ",
                        "Alt tarafında imzaya benzer bir şey var sanki.",
                        "Bu? Bu Rhoecus'un Nyx figürü! ",
                        "Şu an elimizde tuttuğumuz şey zamanının en değerli sanatçısının şaheseri.",
                        "Daha önce bulduğun altın sikkeden sonra daha ilginç bir şey bulamayacağımızı düşünmüştüm.",
                        "Yanılmışım. Hem de ne yanılmak. Bu heykel altından bile daha değerli!"
                    }
                )
            },
            {
                "TalePiece1",
                new QuestObject(
                    "Efsane Parçası 1 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            },
            {
                "TalePiece2",
                new QuestObject(
                    "Efsane Parçası 2 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            },
            {
                "TalePiece3",
                new QuestObject(
                    "Efsane Parçası 3 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            },{
                "0",
                new QuestObject(
                    "Büyük İskender'in tablosu",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Evet bu kişiyi tanıyorum. Kendisi zamanında asya kıtasının neredeyse tamamını ve afrika ve avrupanın da bazı bölgelerini yönetmiş olan pek çok sanatçı ve tarihçi tarafından adı sıkça duyulmuş olan Büyük İskender.",
                        "Tam olarak bu tablosunu hiç görmemiştim ama yapıldığı tarihe bakacak olursak kesinlikle Büyük iskender hala hayattayken yapıldığını söyleyebiliriz."
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Bereket tanrıçası Artemisin, bir doğuma yardım edişinin tablosu",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Bu da ne böyle? Daha önce hiç görmediğim bir sanat jenerasyonunda yapılmışa benziyor.",
                        "Tabloda en belirgin olan kişi ortadaki doğum yapan kadın ve ona yardımcı oluyor gibi görünen başka bir kadın.",
                        "Ne anlama geldiğini hiç bilemiyorum."
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Nyx Figürü",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Hah bir heykel daha. ",
                        "Alt tarafında imzaya benzer birşey var sanki.",
                        "Bu? Bu Rhoecus'un Nyx figürü! ",
                        "Şuan elimizde tuttuğumuz şey zamanının en değerli Sanatçısının Şaheseri.",
                        "Daha önce bulduğun altın sikkeden sonra daha ilginç bir şey bulamayacağımızı düşünmüştüm.",
                        "Yanılmışım. Hem de ne yanılmak. Bu heykel altından bile daha değerli!"
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Efsane Parçası 1 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            },
            {
                "4",
                new QuestObject(
                    "Efsane Parçası 2 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            },
            {
                "5",
                new QuestObject(
                    "Efsane Parçası 3 (Parşömen)",
                    Npcs.Profesor,
                    new List<string>(){
                        "Bu da ne? Bir parça parşömene benziyor.",
                        "Antik Yunanca yazıları tercüme etmek biraz zaman alabilir. Bu sırada sen gidip başka Parşömen parçası var mı bak."
                    }
                )
            }
        });

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "Demek \"Herostratik ün\" bu yangını başlatan kişinin adından dolayı çıkmış. ",
                "Sonra ne oldu acaba? Yani milattan önce 356 yılında Büyük iskender doğduktan sonra buraya hiç yolu düştü mü?",
                "Peki ya yerel halk? Krallar, tüccarlar, burayı yuva edinen kişiler yıkıldıktan sonra bir daha geri dönmediler mi?",
                "Daha fazla araştırmalıyız. Hikaye burada bitemez!"
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
                GlobalVariables.PlayerName + " Topladığın Parşömen parçalarını bir araya getirip tercüme ettim. Ve muhteşem bir efsane yazıyordu."
            },
            new TempleInfo(
                "Artemis Tapınağı",
                "MÖ 323",
                new List<string>(){
                    "Mimar : Endoeus (ve daha pek çok mimar), Efesliler tarafından fonlandı.",
                    "\tBüyük iskender ve Artemis Tapınağının Öyküsü : ",
                    "Büyük iskender savaştan çıkmış ve yorgun şekilde çadırında dinlenirken dışarıda konuşan bir konu dikkatini çeker.",
                    "Askerler bir tapınaktan bahsetmektedir. Savaştıkları bölgeye yakın bir kentte kurulmuş fakat yıllar önce yıkılmış olan bir tapınaktır bu.",
                    "Büyük iskender bu tapınak hakkında ne bildiğini sorduğunda şaşıran asker : \"Bereket ve av tanrıçası Artemis'in tapınağı efendim. Yıllar önce yıkılmış.\" demiştir.",
                    "Bu olay üstüne rotasını değiştirerek tapınağa yönelen Büyük iskender ne ile karşılaşacağını çok iyi bilmektedir. Bu aynı zamanda Doğurganlık Tanrıçası da olan Tanrıça Artemisin Tapınağıdır.",
                    "Tapınağa vardıklarında yıkık dökük bir mermer yığınıyla karşılaşan Büyük İskender, tapınağın yapılmış olduğu kentin halkı olan Efeslilerin yöneticileri ile konuşarak onlardan tapınağı onarmak için izin almak ister.",
                    "Çünkü Tanrıça Artemisin kendi tapınağını koruyamamasına sebep olan yangın sırasında Kendisinin doğumu için annesine yardımcı olduğunu düşünmektedir.",
                    "Efeslilerden tek dileği tapınağın yapımı tamamlandığında kendisinin de bu tapınakta adına yer verilmesidir.",
                    "Efes halkının yöneticileri Büyük iskenderin bu isteğini hiç hoş görmezler, fakat yanında getirdiği orduyu göz önüne alarak isteğini reddetmekten çekinirler.",
                    "Yöneticilerden biri sonunda Büyük iskenderin huzuruna çıkarak der ki : \"Bir tanrı bir başka tanrının tapınağını yapmamalı.\"",
                    "Yöneticinin bu sözünden etkilenen Büyük İskender, övgüden memnun kalarak efes kentinden tapınağı onarmadan ayrılır.",
                    "Aradan geçen zamanda Büyük İskender, Anadoluda ve sonrasında Pers İmparatorluğu ile savaşırken Efes Kentinin halkı da yavaş yavaş tapınağı onarmaya başlarlar.",
                    "Önceki iki tapınaktan bile büyük olacak şekilde neredeyse bir stadyum boyutunda olacaktır(137m x 69m x 18m). Ortasında devasa bir Artemis Heykeli bulunan Cella'yı 127 den fazla sütun çevreleyecektir. Haliyle bu muazzam yapıyı bitirmeleri yıllar alır. ",
                    "\tTanrıça Artemisin Unutulması ve Tapınağın yıkılışı",
                    "Tapınak onarıldıktan sonra yaklaşık 600 yıl ayakta kaldı. Hristiyanlığın yayılması ile birlikte gerçekleşen Haçlı Seferlerinde Efesliler tapınağın Hristiyanlılar tarafından lekelenmesinden endişe duysalarda ellerinden bir şey gelmemekteydi.",
                    "Milattan sonra 2. yüzyılda gerçekleşen tapınakta yapılan bir Hristiyan Şeytan çıkarma ayini sırasında Artemisin Sunağı bir anda paramparça olunca, oradaki Efeslilerin çoğu kaçsa da bir kısmı da hristiyan olmayı kabul etti. ",
                    "Böylece Artemis tapınağı ihtiyacı olanlar için bir sığınak, büyük tüccarlar için bir turizm mekanı olmaktan çıkıp tarihin tozlu sayfalarına gömülmeye başladı."
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
                    "Büyük İskender'in tablosu",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Evet bu kişiyi tanıyorum. Kendisi zamanında asya kıtasının neredeyse tamamını ve afrika ve avrupanın da bazı bölgelerini yönetmiş olan pek çok sanatçı ve tarihçi tarafından adı sıkça duyulmuş olan Büyük İskender.",
                        "Tam olarak bu tablosunu hiç görmemiştim ama yapıldığı tarihe bakacak olursak kesinlikle Büyük iskender hala hayattayken yapıldığını söyleyebiliriz."
                    }
                )
            },

        });

        tempConversationList = new List<QuestConversation>(){
            new QuestConversation(Npcs.Profesor,new List<string>(){
                "Demek \"Herostratik ün\" bu yangını başlatan kişinin adından dolayı çıkmış. ",
                "Sonra ne oldu acaba? Yani milattan önce 356 yılında Büyük iskender doğduktan sonra buraya hiç yolu düştü mü?",
                "Peki ya yerel halk? Krallar, tüccarlar, burayı yuva edinen kişiler yıkıldıktan sonra bir daha geri dönmediler mi?",
                "Daha fazla araştırmalıyız. Hikaye burada bitemez!"
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
                GlobalVariables.PlayerName + " topladığın Parşömen parçalarını bir araya getirip Tercüme ettim. Ve muhteşem bir Efsane yazıyordu."
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
