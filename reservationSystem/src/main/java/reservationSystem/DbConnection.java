package reservationSystem;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DbConnection {
	
    private static final String url = "jdbc:postgresql://localhost:5432/RoyalInn";
    private static final String username = "postgres";
    private static final String password = "postgres";
//    private static final String password = "postgres1";

	public Connection getConnection() {
		try{
	            Class.forName("org.postgresql.Driver");
	            Connection connection = DriverManager.getConnection(url, username, password);
	            return connection;
			}catch (ClassNotFoundException e){
			System.out.println("Failed to load driver");
			} catch (SQLException e) {
			System.out.println("Failer to connect to server");
			}
		return null;
    }
}
