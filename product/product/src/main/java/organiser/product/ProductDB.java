package organiser.product;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductDB extends JpaRepository<Product,Integer>{				//Created interface instead of a class
	Product findByName(String name);
}
