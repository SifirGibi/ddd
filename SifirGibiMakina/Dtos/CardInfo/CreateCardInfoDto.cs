using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.CardInfo
{
    public class CreateCardInfoDto
    {
        public string CardToken { get; set; }
        public string CardUserKey { get; set; }
        public string BinNumber { get; set; }
        public string ConversationId { get; set; }
        public string Locale { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string CardType { get; set; }
        public string CardFamily { get; set; }
        public Nullable<int> SystemTime { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}