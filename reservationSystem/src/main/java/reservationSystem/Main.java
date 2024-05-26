package reservationSystem;
import java.sql.SQLException;
import java.sql.Connection;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws SQLException {
    	Scanner scanner = new Scanner(System.in);
    	DbConnection db = new DbConnection();
    	Connection connection = db.getConnection();
		try {
        	if(connection == null)System.out.println("Try again in some time!!!");
        	else {
        	while(true){
                System.out.println();
                System.out.println("WELCOME TO ROYAL INN RESERVATION MANAGEMENT SYSTEM");
                System.out.println("1. Reserve a room");
                System.out.println("2. View Reservations");
                System.out.println("3. Get Room Number");
                System.out.println("4. Update Reservations");
                System.out.println("5. Delete Reservations");
                System.out.println("0. Exit");
                System.out.print("Choose an option: ");
                int choice = scanner.nextInt();
                switch (choice) {
                    case 1:
                        Service.reserveRoom(connection, scanner);
                        break;
                    case 2:
                    	Service.viewReservations(connection);
                        break;
                    case 3:
                    	Service.getRoomNumber(connection, scanner);
                        break;
                    case 4:
                    	Service.updateReservation(connection, scanner);
                        break;
                    case 5:
                    	Service.deleteReservation(connection, scanner);
                        break;
                    case 0:
                    	Service.exit();
                    	scanner.close();
                        return;
                    default:
                        System.out.println("Invalid choice. Try again.");
                }
        	}
        	}
            

        }catch (SQLException e){
            System.out.println(e.getMessage());
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
		scanner.close();	
    }

    
}
