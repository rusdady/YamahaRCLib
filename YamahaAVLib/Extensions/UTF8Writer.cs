using System.IO;
using System.Text;

namespace YamahaAVLib.Extensions
{
    /// <summary>
    /// StringWriter advertises itself as using UTF-16 and so we get generated xml root as
    /// <?xml version=\1.0\ encoding=\utf-16\?>. But we need utf-8 declaration, and we will
    /// override read-only Encoding property to specify UTF-8 encoding.
    /// </summary>
    internal class UTF8Writer : StringWriter
    {
        public UTF8Writer() : base()
        {
        }
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}
