package mybatis;

import java.util.List;
import org.apache.ibatis.session.SqlSession;

public class BookDAO {

	// insert
	public void save(Book book) {
		SqlSession session = MyBatisUtil.getSqlSessionFactory().openSession();
		session.insert("mybatis.BookMapper.insertBook", book);
		session.commit();
		session.close();
	}

	// update
	public void update(Book book) {
		SqlSession session = MyBatisUtil.getSqlSessionFactory().openSession();
		session.update("mybatis.BookMapper.updateBook", book);
		session.commit();
		session.close();
	}

	// delete
	public void delete(String id) {
		SqlSession session = MyBatisUtil.getSqlSessionFactory().openSession();
		session.delete("mybatis.BookMapper.deleteBook", id);
		session.commit();
		session.close();
	}

	// select
	public List<Book> select() {
		SqlSession session = MyBatisUtil.getSqlSessionFactory().openSession();
		List<Book> selectedBook = session.selectList("mybatis.BookMapper.selectBooks");
		session.close();
		return selectedBook;
	}

	// select all
	public List<Book> findAllBooks() {
		SqlSession session = MyBatisUtil.getSqlSessionFactory().openSession();
		List<Book> books = session.selectList("mybatis.BookMapper.findAllBooks");
		session.close();
		return books;
	}

}