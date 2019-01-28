using Swintake.domain.Data;
using Swintake.infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swintake.domain.FilesToUpload
{
   public class FileRepository
    {
        private readonly SwintakeContext _context;

        public FileRepository(SwintakeContext context)
        {
            _context = context;
        }

        public async Task<FileToUpload> UploadFile(FileToUpload file)
        {
            _context.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }
    }
}
