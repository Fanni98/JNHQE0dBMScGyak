package mybatis;

import java.util.List;
import java.util.Random;

public class App {

	public static void main(String[] args)throws Exception {
		BookDAO bookDAO = new BookDAO();
		Book book = new Book();

		// insert
		Random r = new Random();
		book.setIsbn(String.valueOf(r.nextInt(9000)));
		book.setTitle("Könyv " + r.nextInt(9000));
		book.setPrice(r.nextInt(15000));
		bookDAO.save(book);
		System.out.println("Tárolva: ISBN: " + book.getIsbn() + ", TITLE: " + book.getTitle() + ", PRICE: "
				+ book.getPrice() + "\n");

		// update (ár módosítása megadott ISBN-re)
		Book book1 = new Book();
		book1.setIsbn("A412");
		book1.setPrice(7700);
		bookDAO.update(book1);
		System.out.println("Módosítva: ISBN: " + book1.getIsbn() + ", PRICE: " + book1.getPrice() + "\n");

		// delete
		bookDAO.delete("A413");
		System.out.println("Deleted.");

		// select, ahol ár > 5000
		List<Book> selectedBooks = bookDAO.select();
		System.out.println("\n5000 ár feletti könyvek: ");
		for (Book b : selectedBooks) {
			System.out.println("ISBN: " + b.getIsbn() + ", TITLE: " + b.getTitle() + ", PRICE: " + b.getPrice());
		}

		// összes könyv listázása
		System.out.println("\nÖsszes könyv:");
		List<Book> books = bookDAO.findAllBooks();
		for (Book b : books) {
			System.out.println("ISBN: " + b.getIsbn() + ", TITLE: " + b.getTitle() + ", PRICE: " + b.getPrice());
		}
	}
}
