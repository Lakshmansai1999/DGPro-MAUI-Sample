using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DGProM.Messages;

public class AddProductMessage : ValueChangedMessage<int>
{
    public AddProductMessage(int count) : base(count)
    {
    }
}

