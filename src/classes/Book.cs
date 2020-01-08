using System;

namespace csharp1.classes 
{
    class Book
    {
        public BookProp Author { get; set; }
        public BookProp Title { get; set; }
        public BookProp Content { get; set; }

        public Book(String author, String title, String content) {
            Author = new Author(author);
            Title = new Title(title);
            Content = new Content(content);
        }

        public void Show() {
            Author.Show();
            Title.Show();
            Content.Show();
        }
    }

    abstract class BookProp 
    {

        public BookProp(String val) {
            this.Value = val;
        }
        public String Value { get; set; }

        abstract public ConsoleColor color { get; }

        public void Show()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Value);
            Console.ResetColor();
        }
    }

    class Author : BookProp
    {
        public Author(String val) : base (val) {}
        public override ConsoleColor color { get { return ConsoleColor.Red;} }
    }

    class Title : BookProp
    {
        public Title(String val) : base (val) {}
        public override ConsoleColor color { get { return ConsoleColor.Green;} }
    }

    class Content : BookProp
    {
        public Content(String val) : base (val) {}
        public override ConsoleColor color { get { return ConsoleColor.Blue;} }
    }
}