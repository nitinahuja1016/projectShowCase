package organiser.product;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class ProductService {
	public void show() {
		System.out.println("In show");
	}

	public void addProduct(Product p) {
		db.save(p);
	}

	@Autowired
	ProductDB db;
	public List<Product> getAllProducts() {
		return db.findAll();
		}
	
	public Product getProduct(String name) {
		return db.findByName(name);
		
	}
}
