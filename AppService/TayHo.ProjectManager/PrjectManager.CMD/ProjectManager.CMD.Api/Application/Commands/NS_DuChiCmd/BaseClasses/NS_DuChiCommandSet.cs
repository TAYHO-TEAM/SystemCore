using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_DuChiCommandSet : BaseCommandClasses
    {
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public string ThangBaoCao { get; set; }
        public string ThangDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}