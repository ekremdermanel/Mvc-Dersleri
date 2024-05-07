using System.Diagnostics;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Models;

namespace Test.Controllers;

public class HomeController : Controller
{
    private string dosyaAdi = "test-f4b6e-dbef119a171e.json";
    private string projectId;
    private FirestoreDb db;


    public HomeController()
    {
        string dosyaYolu = Path.Combine(Environment.CurrentDirectory, dosyaAdi);
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", dosyaYolu);
        projectId = "test-f4b6e";
        db = FirestoreDb.Create(projectId);
    }

    public async Task<IActionResult> Index()
    {
        Query query = db.Collection("urunler");
        QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
        List<Urun> list = new List<Urun>();
        foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
        {
            if (documentSnapshot.Exists)
            {
                Dictionary<string, object> item = documentSnapshot.ToDictionary();
                string json = JsonConvert.SerializeObject(item);
                Urun urun = JsonConvert.DeserializeObject<Urun>(json);
                urun.Id = documentSnapshot.Id;
                list.Add(urun);
            }
        }
        return View(list);
    }

    public async Task<IActionResult> Ekle()
    {
        Random rnd = new Random();
        Urun urun = new Urun();
        urun.UrunAdi = Guid.NewGuid().ToString().Substring(0, 8);
        urun.Fiyat = rnd.NextDouble() * 400 + 100;
        CollectionReference collectionReference = db.Collection("urunler");
        await collectionReference.AddAsync(urun);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Sil(string id)
    {
        DocumentReference documentReference = db.Collection("urunler").Document(id);
        await documentReference.DeleteAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Guncelle(string id)
    {
        DocumentReference documentReference = db.Collection("urunler").Document(id);
        DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();
        Dictionary<string, object> item = documentSnapshot.ToDictionary();
        string json = JsonConvert.SerializeObject(item);
        Urun urun = JsonConvert.DeserializeObject<Urun>(json);
        urun.Fiyat *= 2;
        await documentReference.SetAsync(urun, SetOptions.Overwrite);
        return RedirectToAction("Index");
    }
}
