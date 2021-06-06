using System.Collections.Generic;

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