using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public interface ICardService
    {
        Card GetCardByName(string cardName);

    }
}
