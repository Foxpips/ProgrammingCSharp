using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using NUnit.Framework;

namespace MeasureupTests
{
    public class Books
    {
        public class Book
        {
            public BookPublisher BookPublisher { get; set; }
            public string BookAuthor { get; set; }
            public int BookId { get; set; }
        }


        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {BookAuthor = "", BookId = 1, BookPublisher = new BookPublisher {Name = "Ted"}},
//                new Book {,BookId = 2,BookPublisher = new BookPublisher {Name = "Ted 2"}},
//                new Book {,BookId = 3,BookPublisher = new BookPublisher {Name = "Ted 3 Ted Returns"}},
                new Book {BookAuthor = "", BookId = 4, BookPublisher = new BookPublisher {Name = "Ted 4 more Ted"}}
            };
        }
    }

    [Description("999")]
    public class BookPublisher
    {
        public string Name { get; set; }

        protected internal BookPublisher()
        {
        }
    }

    public struct Pointer
    {
        public int X { get; private set; }

        public Pointer(int x)
            : this()
        {
            X = x;
        }
    }


    public class TestBooks
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var books =
                Books.GetBooks().Select(book => new { book.BookId, book.BookAuthor, Publisher = book.BookPublisher.Name });

            books.Each(e => Console.WriteLine(e.Publisher));

            var selectMany =
                Books.GetBooks()
                    .SelectMany(
                        book =>
                            new List<Books.Book> { book }.SelectMany(bookPublisher => new List<Books.Book> { bookPublisher }));
        }


        [Test]
        public void TestAttribute_Scenario_Result()
        {
            object target = new BookPublisher();

            var type = target.GetType();
            var type2 = typeof(DescriptionAttribute);

            CustomAttributeData customAttributeData = (from a in type.CustomAttributes 
                                                       where a.AttributeType == type2 
                                                       select a).FirstOrDefault();
            
            Attribute customAttributes = type.GetCustomAttributes(type2).FirstOrDefault();
            
            IEnumerable<Attribute> firstOrDefault = (from b in type.GetCustomAttributes() 
                                        where b.GetType() == type2 
                                        select b);

            //            GetValue(customAttributeData, customAttributes, firstOrDefault);
        }

        private static void GetValue(CustomAttributeData customAttributeData, Attribute customAttributes,
            Attribute firstOrDefault)
        {
            Assert.NotNull(customAttributeData);
            Assert.NotNull(customAttributes);
            Assert.NotNull(firstOrDefault);

            Type attributeType = customAttributeData.AttributeType;
            Assert.True(firstOrDefault.GetType() == typeof(DescriptionAttribute));
            Assert.True(attributeType == typeof(DescriptionAttribute));
            Assert.True(customAttributes.GetType() == typeof(DescriptionAttribute));
        }
    }
}