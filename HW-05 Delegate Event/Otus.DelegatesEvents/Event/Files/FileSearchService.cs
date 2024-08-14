using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Otus.HW.DelegatesEvents.Files;
using System.Threading;

namespace Otus.HW.DelegatesEvents
{
    /// <summary>
    /// Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
    /// </summary>
    public class FileSearchService
    {
        private readonly string _catalog;

        public event EventHandler<FileArgs> FileFound;
        public CancellationTokenSource _cancelToken;

        public FileSearchService(string catalog, CancellationTokenSource cancelToken)
        {
            _catalog = catalog;
            _cancelToken = cancelToken;
        }

        public void StartFileSearch()
        {
            try
            {
                if (Directory.Exists(_catalog))
                {
                     //поиск по всем файлам в каталоге и подкаталогах
                     foreach (var file in Directory.GetFiles(_catalog, "*.*", SearchOption.AllDirectories))
                     {
                        _cancelToken.Token.ThrowIfCancellationRequested(); // Проверяем, была ли запрошена отмена

                        IsFound(new FileArgs(file));
                        Thread.Sleep(1000); // Подождать перед следующим вызовом
                     }
                }
                else if (File.Exists(_catalog))
                {
                    IsFound(new FileArgs(_catalog));
                }
                else
                {
                    Console.WriteLine("Doesn't exist");
                }
            } 
            catch(Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }

        /// <summary>
        /// Метод вызова события
        /// </summary>
        /// <param name="args"></param>
        protected virtual void IsFound(FileArgs args)
        {
            FileFound?.Invoke(this, args);
        }
    }
}
