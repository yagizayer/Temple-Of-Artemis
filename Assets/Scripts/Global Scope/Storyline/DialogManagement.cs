
using System.Collections.Generic;
using UnityEngine;


public class DialogManagement : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Phase> _storyline = new Dictionary<string, Phase>();
    public Dictionary<string, Phase> Storyline => _storyline;
    void Start()
    {
        SetStoryline();
        Debug.Log(Storyline["EarlyPhase"].Quests["Tutorial"].QuestConversations[0].Lines[0]);
    }
    void SetStoryline()
    {
        PhaseEnd tempPhaseEnd = new PhaseEnd();
        TempleInfo tempTempleInfo = new TempleInfo();

        #region EarlyPhase

        Phase earlyPhase = new Phase();

        Quest tutorial = new Quest();
        tutorial.QuestConversations.AddRange(new List<QuestConversation>(){
                new QuestConversation("Jeolog",new List<string>(){
                    "Daha ne kadar yürümemiz gerek? Güneş beni baymaya başladı."
                }),
                new QuestConversation("Sanat Tarihi Uzmanı",new List<string>(){
                    "Sızlanmayı bırak küçük bebek yerel halk Antik kalıntıların buralarda bir yerde olduğunu söyledi."
                }),
                new QuestConversation("Jeolog",new List<string>(){
                    "Muhtemelen yine sadece bir kaç eski çanak çömlek için bu kadar yol tepmiş olucaz zaten."
                }),
                new QuestConversation("Profesör",new List<string>(){
                    "Sallanmayı bırakın baksanıza ne kadar güzel her yer yeşillik biraz doğanın keyfini çıkartın.",
                    "Sen ne düşünüyorsun Jones ? Buralara kadar gelmeye değer bir manzarayla karşılaşır mıyız sence?"
                }),
                new QuestConversation("Jones",new List<string>(){
                    "Yerel halkın bahsettiği kalıntıları bulamasak bile bu doğal çevre buraya gelmeye değer."
                }),
                new QuestConversation("Profesör",new List<string>(){
                    "Sanırım haklısın buranın havası çok güzel. Ama yine de antik zamanlardan bazı kalıntılar bulmak zarar vermezdi."
                }),
            });

        Quest findAncientColumns = new Quest();
        findAncientColumns.QuestConversations.AddRange(new List<QuestConversation>(){
            new QuestConversation("Profesör",new List<string>(){
                    "Vay anassını neler bulmuşsun Jones."
                }),
            new QuestConversation("Jeolog",new List<string>(){
                    "Sanırım çömleklerden fazlası varmış burada.",
                    "Ölçümlerime göre bu sütunlar en az 2000 yıllık."
                }),
            new QuestConversation("Sanat Tarihi Uzmanı",new List<string>(){
                    "Üzerlerindeki işlemeler çok enteresan dana önce hiç böyle motifler görmemiştim."
                }),
            new QuestConversation("Profesör",new List<string>(){
                    "Acaba etrafta daha fazlası var mıdır?"
                }),
            new QuestConversation("Jones",new List<string>(){
                    "Sanırım bunu arıyorsunuz Profesör."
                }),
        });

        Quest talkToProfessor = new Quest();
        talkToProfessor.QuestConversations.AddRange(new List<QuestConversation>(){
            new QuestConversation("Profesör",new List<string>(){
                    "Bu yapının bunca yıl gizli kalmış olmasına inanabiliyor musun?",
                    "Jeoloğun dedine bakacak olursak en az 2000 yıllık bir tapınak kalıntısına bakıyoruz şu an.",
                    "Acaba kim ne zaman yaptı, biraz etrafa bakınalım belki ipucu olabilecek bazı eşyalara rastlarız."
                }),
        });

        Quest gatherInformationAroundTemple = new Quest();
        gatherInformationAroundTemple.QuestObjects.AddRange<string, QuestObject>(new Dictionary<string, QuestObject>(){
            {
                "PaintingOfAmazons",
                new QuestObject(
                    "Amazonların Resmi",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Jones! Bu tabloyu nereden buldun bunca zamandır neredeyse hiç zarar görmemiş.",
                        "Hmmm. Bu tür dayanıklı tabloları yapan Antik çağda yaşamış olan tek medeniyet Amazonlardı. ",
                        "Sanırım bu tabloyu da onlar yapmış olmalı. "
                    }
                )
            },
            {
                "PaintingOfTreeOfLife",
                new QuestObject(
                    "Hayat Ağacının resmi",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Vaovv şu güzelliğe bak. Bu ağaç sanırım eski şiirlere konu olmuş Hayat Ağacı.",
                        "Milattan önce 300 yıllarında Amazonlar İyonyadan buraya göçerken bu tür eserleri ve hikayelerini de yanlarında getirmişlerdi."
                    }
                )
            },
            {
                "BrokenSculpture",
                new QuestObject(
                    "Kırık Heykelcik",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Vay canına. Ne kadar da iyi muhafaza edilmiş bir heykel bu böyle.",
                        "Bakalım kaç yaşındaymışsın sen... ",
                        "Jones. Bu minik dostumuz neredeyse profesörün yaşında... Tabii 40 katı olduğunu saymazsak!",
                        "Bu şey tam 2200 yıldır kırılmadan, bozulmadan burada duruyormuş."
                    }
                )
            },
            {
                "AmberNecklace",
                new QuestObject(
                    "Kehribar Kolye",
                    Npcs.Jeolog,
                    new List<string>(){
                        "O elindeki ne öyle Jones? ",
                        "Bakalım... Görünüşe göre bu bir kolye ucu.",
                        "Bak iki yanında delikler var. Büyük ihtimalle bu tapınağın ithaf edildiği Tanrıça için yapılmış bir eser.",
                        "Zamanında bu tür kolyeler çok kıymetliydi. Kimsenin bunca zaman çalmamış olmasına şaşırdım doğrusu."
                    }
                )
            },
            {
                "FigureOfTreeOfLife",
                new QuestObject(
                    "Hayat ağacı Kabartması",
                    Npcs.Profesor,
                    new List<string>(){
                        "Evet... Çok ilginç...",
                        "Antik zamanlardan kalma Hayat ağacı inancını tasfir eden bir kabartma bulmuşsun Jones.",
                        "Bu öyle bir ağaçmış ki Cennet ve Cehennemi birbirine bağlar, Tüm yaşam bu ağaçtan ortaya çıkar ve yine bu ağaca dönermiş. ",
                        "Pek çok din, felsefe ve mitoloji bu ağaçtan bahseder. Sanırım bu da Hayat Ağacının işlediği ilk eserlerden biri."
                    }
                )
            },{
                "0",
                new QuestObject(
                    "Amazonların Resmi",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Jones! Bu tabloyu nereden buldun bunca zamandır neredeyse hiç zarar görmemiş.",
                        "Hmmm. Bu tür dayanıklı tabloları yapan Antik çağda yaşamış olan tek medeniyet Amazonlardı. ",
                        "Sanırım bu tabloyu da onlar yapmış olmalı. "
                    }
                )
            },
            {
                "1",
                new QuestObject(
                    "Hayat Ağacının resmi",
                    Npcs.SanatTarihiUzmani,
                    new List<string>(){
                        "Vaovv şu güzelliğe bak. Bu ağaç sanırım eski şiirlere konu olmuş Hayat Ağacı.",
                        "Milattan önce 300 yıllarında Amazonlar İyonyadan buraya göçerken bu tür eserleri ve hikayelerini de yanlarında getirmişlerdi."
                    }
                )
            },
            {
                "2",
                new QuestObject(
                    "Kırık Heykelcik",
                    Npcs.Jeolog,
                    new List<string>(){
                        "Vay canına. Ne kadar da iyi muhafaza edilmiş bir heykel bu böyle.",
                        "Bakalım kaç yaşındaymışsın sen... ",
                        "Jones. Bu minik dostumuz neredeyse profesörün yaşında... Tabii 40 katı olduğunu saymazsak!",
                        "Bu şey tam 2200 yıldır kırılmadan, bozulmadan burada duruyormuş."
                    }
                )
            },
            {
                "3",
                new QuestObject(
                    "Kehribar Kolye",
                    Npcs.Jeolog,
                    new List<string>(){
                        "O elindeki ne öyle Jones? ",
                        "Bakalım... Görünüşe göre bu bir kolye ucu.",
                        "Bak iki yanında delikler var. Büyük ihtimalle bu tapınağın ithaf edildiği Tanrıça için yapılmış bir eser.",
                        "Zamanında bu tür kolyeler çok kıymetliydi. Kimsenin bunca zaman çalmamış olmasına şaşırdım doğrusu."
                    }
                )
            },
            {
                "4",
                new QuestObject(
                    "Hayat ağacı Kabartması",
                    Npcs.Profesor,
                    new List<string>(){
                        "Evet... Çok ilginç...",
                        "Antik zamanlardan kalma Hayat ağacı inancını tasfir eden bir kabartma bulmuşsun Jones.",
                        "Bu öyle bir ağaçmış ki Cennet ve Cehennemi birbirine bağlar, Tüm yaşam bu ağaçtan ortaya çıkar ve yine bu ağaca dönermiş. ",
                        "Pek çok din, felsefe ve mitoloji bu ağaçtan bahseder. Sanırım bu da Hayat Ağacının işlediği ilk eserlerden biri."
                    }
                )
            }
        });
        gatherInformationAroundTemple.QuestConversations.AddRange(new List<QuestConversation>(){
            new QuestConversation("Profesör",new List<string>(){
                "Bu yapının bunca yıl gizli kalmış olmasına inanabiliyor musun?",
                "Jeoloğun dedine bakacak olursak en az 2000 yıllık bir tapınak kalıntısına bakıyoruz şu an.",
                "Acaba kim ne zaman yaptı, biraz etrafa bakınalım belki ipucu olabilecek bazı eşyalara rastlarız."
            })
        });

        earlyPhase.Quests.AddRange<string, Quest>(new Dictionary<string, Quest>(){
            {"Tutorial",tutorial},
            {"FindAncientColumns",findAncientColumns},
            {"TalkToProfessor",talkToProfessor},
            {"GatherInformationAroundTemple",gatherInformationAroundTemple}
        });

        earlyPhase.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                "Jones topladığın ipuçlarını bir araya geldiğinde bu tapınağın ne olduğu ve ne zaman kimler tarafından yapıldığı anlaşılıyor."
            },
            new TempleInfo(
                "Kayıp Artemis Tapınağı",
                "MÖ 3300 ~ MÖ 1200 arası",
                new List<string>(){
                    "Mimar : Amazonlar",
                    "Yapım Sebebi : Tanrı Dionysus ve yandaşları Amazonlara savaş açtığında Avcılık ve bereket tanrıçası olan Artemise sığınmak için bu tapınağı yaptılar.",
                    "Yıkım Sebebi : MÖ 700 lü yıllarda Ege denizindeki bir fırtına sonucunda oluşan devasa bir sel"
                }
            ),
            new List<string>()
            {
                "Demek efsanelerde bahsedilen kayıp artemis tapınağı burasıymış.",
                "Peki ama sonra ne oldu acaba. Yani milattan önce 7. yüzyıldan bu yana hiç kimse gelmedi mi acaba bu tapınağa?",
                "Bence bu doğru olamaz ipuçları aramalıyız! Buranın tarihini öğrenmeliyiz!"
            }
        );

        Storyline.Add("EarlyPhase", earlyPhase);

        #endregion EarlyPhase




    }
}
