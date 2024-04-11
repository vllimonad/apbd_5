using apbd5.Controllers;
using apbd5.Models;

namespace apbd5.Database;

public class AnimalDatabase
{
    public static List<Animal> animals = new List<Animal>()
    {
        new Animal()
        {
            id = 1, category = "cat", name = "joe", weight = 2.1, furColor = "wejc"
        },
        new Animal()
        {
            id = 2, category = "dog", name = "loo", weight = 12.7, furColor = "iyrc"
        }
    };

    public static List<Visit> visits = new List<Visit>();
}