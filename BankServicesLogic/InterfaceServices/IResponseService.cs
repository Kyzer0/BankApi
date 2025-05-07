
using CostumeResponse;
namespace BankServicesLogic.InterfaceServices
{
    internal interface IResponseService<T>
    {
        ResponseAccount ValidateAccount(T account);
    }
}
