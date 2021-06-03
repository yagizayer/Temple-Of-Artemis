using System.Collections;
using System.Collections.Generic;

static public class AllDialogs
{

}
public struct Phase
{
    // Bölüm içerisindeki tüm konuşmaların saklandığı sınıf.
}
public class Conversation
{
    // birden çok birey arasındaki tek bir seferde yapılan karşılıklı konuşma.
    // Doldurma : Conversation(person1,person2)

    public Conversation(List<string> speakers, )
    {
    }
    private List<string> _speakers;
    public List<string> Speakers => _speakers;
    private int _currentParagraphNo = 0;
    public int CurrentParagraphNo => _currentParagraphNo;

    private List<Paragraph> _allParagraphs;

    public Paragraph NextParagraph
    {
        get
        {
            return null;
        }
    }

}

public class Paragraph
{
    // bir bireyin tek seferde söyleyeceği ard arda cümleler.
    // Doldurma : Paragraph("karakterAdı",15,karakterinTekSeferdeSoyleyecegiButunSatirlar);
    // Boşaltma : Debug.Log(personTemp.NextLine);

    public Paragraph(string name, int orderOfLines, List<string> allLines)
    {
        Character = name;
        _order = orderOfLines;
        _lines = allLines;
    }
    // Konuşan karakterin adı
    private string _character;
    public string Character
    {
        get { return _character; }
        set
        {
            _character = value;

        }
    }

    // Karakterin Sözünün bittiğini işaret eden String
    private string _triggerString = "__!";
    public string TriggerString
    {
        get { return _triggerString; }
        set
        {
            _triggerString = value;
        }
    }

    // Bu Dizelerin konuşmadaki sırasını belirten int
    private int _order;
    public int Order => _order;
    // Dizeler arasında kaçıncı sırada olduğunu tutan int
    private int _currentLineNo = 0;
    public int CurrentLineNo => _currentLineNo;
    // Karakterin tek seferde söyleyeceği tüm dizeler
    private List<string> _lines;
    public List<string> Lines => _lines;
    // Karakterin söyleyeceği sonraki dizeyi veren string
    public string NextLine
    {
        get
        {
            if ((CurrentLineNo + 1) == Lines.Count) return TriggerString;
            return Lines[_currentLineNo++];
        }
    }
}