using log4net.Core;
using log4net.Layout.Pattern;
using System.IO;

namespace Platform.Tool.ClientUnityLogger.API
{
    public class MessageEscapeConvertor : PatternLayoutConverter {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent) {
            throw new global::System.NotImplementedException();
        }
    }
}
