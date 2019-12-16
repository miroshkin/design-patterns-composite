using System;
using System.Collections.Generic;

namespace DesignPatterns_Composite
{
    //original source https://metanit.com/sharp/patterns/4.4.php
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Composite!");

            Component fileSystem = new Directory("File system");
            Component diskC = new Directory("Disk C:");

            Component pngFile = new File("image.png");
            Component docxFile = new File("report.docx");

            diskC.Add(pngFile);
            diskC.Add(docxFile);

            fileSystem.Add(diskC);
            fileSystem.Print();
            Console.WriteLine();

            Component myDocumentsFolder = new Directory("MyDocuments");
            Component mySong = new File("MySong.mp3");

            myDocumentsFolder.Add(mySong);
            fileSystem.Add(myDocumentsFolder);
            diskC.Remove(pngFile);

            fileSystem.Print();


        }
    }

    abstract class Component
    {
        protected string _name;

        public Component(string name)
        {
            _name = name;
        }

        public virtual void Add(Component component)
        {
        }

        public virtual void Remove(Component component){}

        public virtual void Print()
        {
            Console.WriteLine(_name);
        }
    }

    class Directory : Component
    {
        private List<Component> _components = new List<Component>();

        public Directory(string name) : base(name)
        {

        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Root:" + _name);
            Console.WriteLine("Leaves:");
            _components.ForEach(c => c.Print());
        }

    }

    class File : Component
    {
        public File (string name) : base (name){}
    }
}
