using Microsoft.ML.Data;

namespace App_MAUI_Enterprise.MLConsume.DataStructure
{
    public class SentimentIssue
    {
        [LoadColumn(0)]
        public bool Label { get; set; }
        [LoadColumn(2)]
        public string Text { get; set; }
    }
}