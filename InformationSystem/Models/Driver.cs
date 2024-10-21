using System.ComponentModel.DataAnnotations;

namespace InformationSystem.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public string CarReg { get; set; }
        public DateTime NoteDate { get; set; }
        public string NoteDescription { get; set; }
        public string ResponsibleEmployee { get; set; }
        public decimal TotalAmountOut { get; set; }
        public decimal TotalAmountIn { get; set; }

        //nav prop
        public ICollection <Event> Events { get; set; }
    }
}
