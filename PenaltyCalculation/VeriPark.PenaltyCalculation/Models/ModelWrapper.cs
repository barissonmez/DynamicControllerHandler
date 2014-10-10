
namespace VeriPark.PenaltyCalculation.Models
{
    public class ModelWrapper
    {
        public ModelWrapper()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public PenaltyCalculationResultOutModel Result { get; set; }
    }
}