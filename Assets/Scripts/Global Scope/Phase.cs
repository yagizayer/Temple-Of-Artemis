using System.Collections.Generic;

public class Phase
{
    // Bölüm içerisindeki tüm konuşmaların saklandığı sınıf.

    public Phase(List<Conversation> conversations)
    {
        _conversations = conversations;
    }
    private List<Conversation> _conversations;
    public List<Conversation> Conversations
    {
        get { return _conversations; }
    }
}
