using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Test.Models
{
    [FirestoreData]
    public class Urun
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string UrunAdi { get; set; }
        [FirestoreProperty]
        public double Fiyat { get; set; }
    }
}