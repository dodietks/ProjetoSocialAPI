using System.Collections.Generic;

namespace ProjetoSocialAPI.Data.Converter.Contract
{
    public interface IParser<In, Out>
    {
        Out Parse(In origin);
        List<Out> Parse(List<In> origin);
    }
}
