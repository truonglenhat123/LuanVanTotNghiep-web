using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Services.Product
{
    public interface IProductService
    {
        void AddFeedback(AddFeedback addFeedback);
    }
}
