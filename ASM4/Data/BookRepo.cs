using AMS4.Models;

namespace AMS4.Data
{
    public class BookRepo : IBook
    {
        List<Book> books;
        public BookRepo()
        {
            books = new List<Book>();
            books.Add(new Book()
            {
                Id = 1,
                Title = "Cho tôi xin một vé đi tuổi thơ",
                Author = "Nguyễn Nhật ánh",
                Description = "Trên mạch kể hấp dẫn của câu chuyện, ngược dòng thời gian, nhà văn đã đưa độc giả trở lại những năm tháng tuổi thơ vui vẻ với cốt truyện xoay quanh 4 bạn nhỏ nghịch ngợm, hồn nhiên cu Mùi, thằng Hải cò, Tí sún và con Tủn. Trong thế giới tuổi thơ tươi đẹp ấy của những đứa trẻ, chúng không hề có những lo toan, bộn bề về cuộc sống vật chất và tinh thần mà chỉ hạnh phúc đắm chìm vào những trò chơi, những vui đùa của tuổi nhỏ. Trải dài trên từng trang viết là những câu chuyện hài hước, dí dỏm, những trò đùa vui vẻ khiến độc giả thực sự ước ao được quay lại những cảm xúc trong sáng, quãng thời gian vô tư như vậy một lần nữa.",
                Price = 100,
                Image = "1.jpg"
            });

            books.Add(new Book()
            {
                Id = 2,
                Title = "Chú bé rắc rối",
                Author = "Nguyễn Nhật ánh",
                Description = "Câu truyện xoay quanh hai cậu bé An và Nghi. An là một đứa học trò học kém và lười học. Do phong trào đôi bạn cùng tiến mà Nghi bất đắc dĩ phải kèm cho An học. Từ đó dần dần hai người trở nên thân thiết. Những buổi chiều học kèm thì Nghi lại bị An dụ đi đá bóng, đi công viên, đi coi chiếu bóng… Tất nhiên có đứa học trò nào mà chẳng mê chơi, mê cả trò nghịch ngợm, khám phá. An là một đứa rất bạo gan cùng với Nghi cả hai đã phát hiện ra những bí mật khủng khiếp. Cũng xuất phát từ tính sợ ma của Nghi mà An đã quyết định rủ Nghi đi khám phá cái lò thịt cũ đó để hòng tìm ra chân tướng.",
                Price = 120,
                Image = "2.jpg"
            });
            books.Add(new Book()
            {
                Id = 3,
                Title = "Hoa hồng xứ khác",
                Author = "Nguyễn Nhật ánh",
                Description = "Mở đầu truyện đã có chút gì đó quen thuộc, nhưng cũng rất lạ. Lạ ở nhân vật nam chính Khoa quá sợ phụ nữ, một điểm khá đặc biệt trong truyện Nguyễn Nhật Ánh. Vì truyện của bác thì các nam chính thường nhát gái hơn là sợ đến mức hận như anh này. Quen thuộc khi truyện tiếp tục mô típ thanh xuân vườn trường. =)) Những chuỗi ngày sinh viên của ba anh chàng Khoa, Ngữ và Hòa lé theo đuổi mù quáng cô nàng Gia Khanh da bezttt.",
                Price = 110,
                Image = "3.jpg"
            });

            books.Add(new Book()
            {
                Id = 4,
                Title = "Thằng quỷ nhỏ",
                Author = "Nguyễn Nhật ánh",
                Description = "Chuyển vào trường mới, Nga (nữ) được xếp ngồi cạnh Quỳnh (nam) – một anh chàng xấu xí với cái mũi to ửng đỏ và đôi tai to có thể cử động. Quỳnh có nhiều tài lẻ, thường bị bạn bè bắt diễn trò vui, một lần bị giáo viên gọi là “thằng quỷ nhỏ” nên chết danh từ đó, chứ thật ra Quỳnh rất nhút nhát. Trong lớp chỉ có Nga chơi với Quỳnh nên họ rất khắng khít. Khải (nam) – bạn cùng lớp – thích Nga, thường đến nhà Nga lấy lòng nhưng Nga lại không ưa Khải chút nào.",
                Price = 185,
                Image = "4.jpg"
            });

            books.Add(new Book()
            {
                Id = 5,
                Title = "Cô gái đến từ hôm qua",
                Author = "Nguyễn Nhật ánh",
                Description = "Câu chuyện trong “Cô Gái Đến Từ Hôm Qua” kể về mối tình học trò của chàng trai tên Anh Thư và cô bạn cùng lớp tên Việt An. Cùng với sự giúp đỡ nhiệt tình của “quân sư” Hải- người bạn thân của mình, Anh Thư đã tìm mọi cách để gây ấn tượng và bày tỏ tình cảm chân thành với Việt An. Nhưng, sau quá trình “cưa đổ” cô nàng, Anh Thư lại nhận ra Việt An chính là cô bạn nhỏ Tiểu Ly thân thiết thời thơ ấu của mình. Cảm xúc trực trào, vừa ngạc nhiên, vừa vui mừng, lại có chút nghẹn ngào đến với đôi bạn Anh Thư- Việt An. Một mối tình như đã được định mệnh sắp đặt sẵn.",
                Price = 210,
                Image = "5.jpg"
            });
        }
        public void Delete(int id)
        {
            Book? find = FindById(id);
            if (find != null)
            {
                books.Remove(find);
            }
        }

        public Book? FindById(int id)
        {
           return books.FirstOrDefault(x => x.Id == id);    
        }

        public List<Book> GetAll()
        {
            return books;
        }

        public void Insert(Book p)
        {
            books.Add(p);   
        }

        public void Update(Book p)
        {
            Book? find = FindById(p.Id);
            if (find != null)
            {
                find.Title = p.Title;
                find.Author = p.Author;
                find.Description = p.Description;
                find.Price = p.Price;
                find.Image = p.Image;
            }
        }
    }
}
