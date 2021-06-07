
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

        #region FirstTemple

        Phase firstTemple = new Phase();

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
                        "Ah. her zamanki gibi küçük taşlar kayalar bana gelir. ",
                        "Neden sanat tarihi okumadım ki sank... Bir saniye bu normal bir taş değil.",
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
                    "Kralın birinden Bir parça kumaş",
                    Npcs.Profesor,
                    new List<string>(){
                        "Jones bu bulduğun kumaş parçası döneminin en kaliteli terzileri tarafından çok pahalı kumaşlardan yapılmış bir kıyafete ait gibi görünüyor.",
                        "Muhtemelen bir krala yada çok zengin bir tüccara aitti bu kıyafet.",
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
                        "Jones bu bulduğun kumaş parçası döneminin en kaliteli terzileri tarafından çok pahalı kumaşlardan yapılmış bir kıyafete ait gibi görünüyor.",
                        "Muhtemelen bir krala yada çok zengin bir tüccara aitti bu kıyafet.",
                        "Düşünce şaşırtıcı değil. Zamanında bu tür tapınaklar çok az bulunurdu ve dünyanın dört bir yanından zenginleri kendisine çekerdi.",
                        "Bu tapınaklara gelen zenginler başıta bulunup dua ederler ve ihtiyacı olanlar da buralarda toplanarak gelen zenginlerden yardım kabul ederlerdi."
                    }
                )
            }
        });
        gatherInformationAroundTemple.QuestConversations.AddRange(new List<QuestConversation>(){
            new QuestConversation("Profesör",new List<string>(){
                "Demek efsanelerde bahsedilen kayıp artemis tapınağı burasıymış.",
                "Peki ama sonra ne oldu acaba. Yani milattan önce 7. yüzyıldan bu yana hiç kimse gelmedi mi acaba bu tapınağa?",
                "Bence bu doğru olamaz ipuçları aramalıyız! Buranın tarihini öğrenmeliyiz!"
            })
        });

        firstTemple.Quests.AddRange<string, Quest>(new Dictionary<string, Quest>(){
            {"GatherInformationAroundTemple",gatherInformationAroundTemple}
        });

        firstTemple.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                "Jones topladığın ipuçlarını bir araya geldiğinde Antik Artemis Tapınağına ne olduğu ve burada neler yaşandığı biraz daha açıklanıyor."
            },
            new TempleInfo(
                "Artemis Tapınağı",
                "MÖ 550",
                new List<string>(){
                    "Mimar : Chersiphron ve onun oğlu Metagenes(Vitruvius), Kral Croesus tarafından fonlandı.",
                    "Kullanımı : Krallar ve Tacirler tarafından sıkça ziyaret edilen turistik bir yapı haline gelen bu tapınak, Aciz durumda olan veya Zulümden kaçanlar için de güvenli bir sığınak oldu. ",
                    "Yıkımı : MÖ 356'da Herostratos adındaki bir meczup yerel halktaki kötü niyetli kişiler tarafından \"Bu tapınağı yıkan kişinin adı bütün tarih kitaplarında geçer\" söylemleri ile kışkırtılarak yangına teşfik edilmiştir. ",
                    "Günümüzde \"Herostratik ün\" deyimi \"Ne pahasına olursa olsun ünlenmek\" manasında kullanılmaktadır. ",
                    "Efsanelerde bu yangın sırasında bereket tanrıçası Artemis'in neden tapınağını korumak için burada olmadığı, çok önemli bir kişinin doğumuna yardım etmek için gittiğinden dolayı burada olmamasına bağlanmaktadır."
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

        Storyline.Add("FirstTemple", firstTemple);

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
                        "Evet bu kişiyi tanıyorum. Kendisi zamanında asya kıtasının neredeyse tamamını ve afrika ve avrupanın da bazı bölgelerini yönetmiş olan pek çok sanatçı ve tarihçi tarafından adı sıkça duyulmuş olan Büyük İskender.",
                        "Tam olarak bu tablosunu hiç görmemiştim ama yapıldığı tarihe bakacak olursak kesinlikle Büyük iskender hala hayattayken yapıldığını söyleyebiliriz."
                    }
                )
            },
            {
                "PaintingOfArtemis",
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
                "NyxFigure",
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
        gatherInformationAroundTemple.QuestConversations.AddRange(new List<QuestConversation>(){
            new QuestConversation("Profesör",new List<string>(){
                "Demek \"Herostratik ün\" bu yangını başlatan kişinin adından dolayı çıkmış. ",
                "Sonra ne oldu acaba? Yani milattan önce 356 yılında Büyük iskender doğduktan sonra buraya hiç yolu düştü mü?",
                "Peki ya yerel halk? Krallar, tüccarlar, burayı yuva edinen kişiler yıkıldıktan sonra bir daha geri dönmediler mi?",
                "Daha fazla araştırmalıyız. Hikaye burada bitemez!"
            })
        });

        lastTemple.Quests.AddRange<string, Quest>(new Dictionary<string, Quest>(){
            {"GatherInformationAroundTemple",gatherInformationAroundTemple}
        });

        lastTemple.PhaseEnd = new PhaseEnd
        (
            new List<string>()
            {
                "Jones topladığın Parşömen parçalarını bir araya getirip Tercüme ettim. Ve muhteşem bir Efsane yazıyordu."
            },
            new TempleInfo(
                "Artemis Tapınağı",
                "MÖ 323",
                new List<string>(){
                    "Mimar : Endoeus (ve daha pek çok mimar), Efesliler tarafından fonlandı.",
                    "\n",
                    "\tBüyük iskender ve Artemis Tapınağının Öyküsü : ",
                    "Büyük iskender Savaştan çıkmış ve yorgun şekilde çadırında dinlenirken dışarıda konuşan bir konu dikkatini çeker.",
                    "Askerler Bir tapınaktan bahsetmektedir. Savaştıkları bölgeye yakın bir kentte kurulmuş fakat yıllar önce yıkılmış olan bir tapınaktır bu.",
                    "Büyük iskender bu tapınak hakkında ne bildiğini sorduğunda şaşıran asker : \"Bereket ve av tanrıçası Artemis tapınağı efendim. yıllar önce yıkılmış.\" demiştir.",
                    "Bu olay üstüne rotasını değiştirerek tapınağa yönelen Büyük iskender ne ile karşılaşacağını çok iyi bilmektedir. Bu aynı zamanda Doğurganlık tanrıçası da olan Tanrıça Artemisin Tapınağıdır.",
                    "Tapınağa vardıklarında yıkık dökük bir mermer yığınıyla karşılaşan Büyük iskender, tapınağın yapılmış olduğu kentin halkı olan Efeslilerin yöneticileri ile konuşarak onlardan tapınağı onarmak için izin almak ister.",
                    "Çünkü Tanrıça Artemisin Kendi tapınağını koruyamamasına sebep olan yangın sırasında Kendisinin doğumu için annesine yardımcı olduğunu düşünmektedir.",
                    "Efeslilerden tek dileği tapınağın yapımı tamamlandığında kendisinin de bu tapınakta adına yer verilmesidir.",
                    "Efes halkının yöneticileri Büyük iskenderin bu isteğini hiç hoş görmezler, fakat yanında getirdiği orduyu göz önüne alarak isteğini reddetmekten çekinirler.",
                    "Yöneticilerden biri sonunda Büyük iskenderin huzuruna çıkarak der ki : \"Bir tanrı bir başka tanrının tapınağını yapmamalı.\"",
                    "Yöneticinin bu sözünden etkilenen Büyük İskender, övgüden memnun kalarak efes kentinden tapınağı onarmadan ayrılır.",
                    "Aradan geçen zamanda Büyük İskender anadoluda ve sonrasında pers imparatorluğu ile savaşırken efes kentinin halkı da yavaş yavaş Tapınağı onarmaya başlarlar.",
                    "Önceki iki tapınaktan bile büyük olacak şekilde neredeyse bir stadyum boyutunda olacaktır(137m x 69m x 18m). Ortasında devasa bir Artemis Heykeli bulunan Cella'yı 127 den fazla sütun çevreleyecektir. Haliyle bu muazzam yapıyı bitirmeleri yıllar alır. ",
                    "\n",
                    "\tTanrıça Artemisin Unutulması ve Tapınağın yıkılışı",
                    "Tapınak onarıldıktan sonra yaklaşık 600 yıl ayakta kaldı. Hristiyanlığın yayılması ile birlikte Gerçekleşen haçlı seferlerinde Efesliler Tapınağın hristiyanlılar tarafından lekelenmesinden endişe duysalarda ellerinden bir şey gelmemekteydi.",
                    "Milattan sonra 2. yüzyılda gerçekleşen Tapınakta yapılan bir Hristiyan Şeytan çıkarma ayini sırasında Artemisin sunağı bir anda paramparça olunca, oradaki efeslilerin çoğu kaçsa da bir kısmı da hristiyan olmayı kabul etti. ",
                    "Böylece Artemis tapınağı İhtiyacı olanlar için bir sığınak, Büyük tüccarlar için bir turizm mekanı olmaktan çıkıp tarihin tozlu sayfalarına gömülmeye başladı."
                }
            ),
            new List<string>()
            {
            }
        );

        Storyline.Add("LastTemple", lastTemple);

        #endregion LastTemple
    }
}
