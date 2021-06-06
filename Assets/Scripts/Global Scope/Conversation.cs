using System.Collections.Generic;

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
