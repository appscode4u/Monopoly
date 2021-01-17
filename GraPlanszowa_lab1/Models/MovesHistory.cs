using System.Collections.Generic;

namespace GraPlanszowa_lab1.Models
{
    public class MovesHistory
    {
        public Dictionary<string, List<HistoryDetail>> History = new Dictionary<string, List<HistoryDetail>>();
    }

    public class HistoryDetail
    {
        public int MoveIntoPosition { get; set; }
        public long Wallet { get; set; }
    }
}
