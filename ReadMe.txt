После загрузки проекта в проекте  ButtonRegistration в папке  _bin_deployableAssemblies исключить из проекта папку не совместитмую с типом вашего проекта.
Тестирование происходило с испосльзованием android симулятора NoxPlayer и веб-сервера IIS Express. Чтобы словить запрос на сервере необходимо в корне приложения , в скрытой папке .vs --> config открыть файл applicationhost.config  и в элементе <sites> --> <site> добавить строчку:  <binding protocol="http" bindingInformation="*:53538:192.168.0.101" />

<site name="ButtonRegistration" id="2">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="G:\RegisterButton-master\RegisterButton-master\ButtonRegistration" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation="*:53538:localhost" />
	  <binding protocol="http" bindingInformation="*:53538:192.168.0.101" />
                </bindings>
 </site>