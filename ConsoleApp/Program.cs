using System;
using System.Collections.Generic;
using Hoplon;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {

            MyCollection collection = new MyCollection();

            var nascimentos = collection.Get("ano.nascimento", 0, -1);

            collection.Add("ano.nascimento", 1980, "pedro");
            //Console.WriteLine("Adicionou item ano.nascimento - 1980 - pedro");
            collection.Add("ano.nascimento", 1980, "maria");
            //Console.WriteLine("Adicionou item ano.nascimento - 1980 - maria");
            collection.Add("ano.nascimento", 1980, "joao");
            //Console.WriteLine("Adicionou item ano.nascimento - 1980 - joao");
            collection.Add("ano.nascimento", 1975, "rodrigo");
            collection.Add("ano.nascimento", 1975, "rodrigo");
            collection.Add("ano.nascimento", 1975, "rodrigo");
            //Console.WriteLine("Adicionou item ano.nascimento - 1975 - rodrigo");
            //Console.WriteLine("");

            //var lista = collection.List();
            //foreach (string item in lista) {
            //    Console.WriteLine(item);
            //}            
            //Console.WriteLine("");

            nascimentos = collection.Get("ano.nascimento", 0, -1);
            Console.WriteLine("Deveria ter 4 elementos: " + nascimentos.Count);
            Console.WriteLine("Deveria ser o elemento 'rodrigo': " + nascimentos[0]);
            Console.WriteLine("Deveria ser o elemento 'joao': " + nascimentos[1]);
            Console.WriteLine("Deveria ser o elemento 'maria': " + nascimentos[2]);
            Console.WriteLine("Deveria ser o elemento 'pedro': " + nascimentos[3]);
            Console.WriteLine("");

            collection.Add("chave", 1, "c");
            //Console.WriteLine("Adicionou item chave - 1 - c");
            collection.Add("chave", 1, "b");
            //Console.WriteLine("Adicionou item chave - 1 - b");
            collection.Add("chave", 1, "a");
            //Console.WriteLine("Adicionou item chave - 1 - a");
            collection.Add("chave", 1, "b");
            collection.Add("chave", 1, "b");
            //Console.WriteLine("Tentou adicionar item chave - 1 - b novamente");
            //Console.WriteLine(string.Concat("Total de itens: ", collection.totalItens.ToString()));
            //Console.WriteLine("");

            //var lista = collection.List();
            //foreach (string item in lista) {
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("");

            var list = collection.Get("chave", 0, 0);
            Console.WriteLine("Deveria ter 1 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'a': " + list[0]);
            Console.WriteLine("");

            list = collection.Get("chave", 0, -2);
            Console.WriteLine("Deveria ter 2 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'a': " + list[0]);
            Console.WriteLine("Deveria ser o elemento 'b': " + list[1]);
            Console.WriteLine("");

            collection.Add("chave", 0, "x");
            list = collection.Get("chave", 0, 0);
            Console.WriteLine("Deveria ter 1 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'x': " + list[0]);
            Console.WriteLine("");

            //Console.WriteLine(string.Concat("Total de itens: ", collection.totalItens.ToString()));
            //collection.RemoveValuesFromSubIndex("ano.nascimento", 1980);
            //Console.WriteLine(string.Concat("Total de itens: ", collection.totalItens.ToString()));
            //Console.WriteLine("");

            //collection.RemoveElement("chave");
            //Console.WriteLine(string.Concat("Total de itens: ", collection.totalItens.ToString()));

            Console.ReadKey();

        }
    }
}
