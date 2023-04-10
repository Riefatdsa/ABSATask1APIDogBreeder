using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Author: Riefat Dollie
 * Module: Test Suite
 * Descr: This module containts the object mapping for the list if breeds using a collection
 * Date:  07/04/2023
 *  */

namespace ABSATask1APIDogBreeder
{
    public class ABSAListOfBreedsDTO
    {
        public Dictionary<string, List<string>> Message { get; set; }
        public string Status { get; set; }
    }
}
