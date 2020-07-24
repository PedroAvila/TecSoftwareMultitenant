using System.Collections.Generic;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class SdConfiguracion
    {
        private readonly ConfiguracionRepository _configuracionRepository = new ConfiguracionRepository();
        private readonly ConfiguracionValidator _configuracionValidator = new ConfiguracionValidator();

        public void CrearXml(Configuracion entity)
        {
            var result = _configuracionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            _configuracionRepository.CrearXml(entity);
        }

        public IEnumerable<UniversalExtend> ListaConfiguracion()
        {
            return _configuracionRepository.ListaConfiguracion();
        }
    }
}
