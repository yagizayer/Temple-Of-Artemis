using System.Collections;
using System.Collections.Generic;

static public class AllDialogs
{

}
public class Phase
{
    // Bölüm içerisindeki tüm konuşmaların saklandığı sınıf.

    public Phase(){

    }

    
}
public class Conversation
{
    // birden çok birey arasındaki tek bir seferde yapılan karşılıklı konuşma.
    // Doldurma : // SIRALI eklenmek zorunda
    /*
        Conversation(
            [
                new Paragraph("KonuşanKişi1", List<string>),
                new Paragraph("KonuşanKişi2", List<string>),
                new Paragraph("KonuşanKişi1", List<string>),
                new Paragraph("KonuşanKişi2", List<string>),
            ] 
        );
    */

    public Conversation(List<Paragraph> completeConversation)
    {
        foreach (Paragraph item in completeConversation)
        {
            _speakers.Add(item.Speaker);
            _allParagraphs.Add(item);
        }
    }
    private List<string> _speakers;
    public List<string> Speakers => _speakers;
    private int _currentParagraphNo = 0;
    public int CurrentParagraphNo => _currentParagraphNo;
    private List<Paragraph> _allParagraphs;
    public List<Paragraph> AllParagraphs => _allParagraphs;
    public Paragraph NextParagraph => _allParagraphs[_currentParagraphNo++];

}

public class Paragraph
{
    // bir bireyin tek seferde söyleyeceği ard arda cümleler.
    // Doldurma : Paragraph("karakterAdı",15,karakterinTekSeferdeSoyleyecegiButunSatirlar);
    // Boşaltma : Debug.Log(personTemp.NextLine);

    public Paragraph(string name, List<string> allLines)
    {
        Speaker = name;
        _lines = allLines;
    }
    // Konuşan karakterin adı
    private string _speaker;
    public string Speaker
    {
        get { return _speaker; }
        set
        {
            _speaker = value;

        }
    }

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
            return Lines[_currentLineNo++];
        }
    }
}