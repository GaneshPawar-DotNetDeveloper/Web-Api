using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web.Mvc;
using StudentApiClient.Models;
using System;
using System.Linq;

namespace StudentApiClient.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> Index()
        {
            IEnumerable<Student> students = null;

            using (var handler = new HttpClientHandler())
            {
                // This is optional if the certificate is already trusted by the system
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true; // Always accept the certificate
                };

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("https://localhost:44368/api/Students");
                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync("Students");
                    if (response.IsSuccessStatusCode)
                    {
                        students = await response.Content.ReadAsAsync<IEnumerable<Student>>();
                    }
                    else
                    {
                        // web api sent error response 
                        students = Enumerable.Empty<Student>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return View(students);
        }

        public ActionResult IndexAjax()
        {
            return View();
        }
    }
    
}
