using ShopOnline.Aplication.ViewModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Interface.Client
{
    public interface ITagServiceClient
    {
        PageResult<TagViewModelClient> GetAllPaggingClient(string keyword, int page, int pageSize);
    }
}
