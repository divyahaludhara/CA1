# EasyDrive Server
# Accepts customer details from client using TCP
# Stores the data in SQLite database
# Generates unique registration number and sends it back to client

import socket
import sqlite3
import json  # JSON is used to send structured data between client and server
import random
from datetime import datetime

def create_database():
    con = sqlite3.connect("EasyDrive.sqlite3")
    print("Connected with the database....")

    cur = con.cursor()

    try:
        cur.execute("drop table if exists Customers")

        cur.execute("""
            CREATE TABLE Customers (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT,
                address TEXT,
                pps_number TEXT,
                driving_license TEXT,
                registration_number TEXT
            )
        """)

        print("Table Customers is ready....")
        con.commit()

    except sqlite3.DatabaseError as e:
        print("This is a database error, cannot create the table...")
        print(e)
        con.rollback()

    except Exception as e:
        print("Error:", e)
        con.rollback()

    finally:
        cur.close()
        con.close()


def generate_registration_number():
    now = datetime.now().strftime("%Y%m%d%H%M%S")
    rand_num = random.randint(100, 999)
    reg_no = "ED" + now + str(rand_num)
    return reg_no


def insert_customer(data, reg_no):
    con = sqlite3.connect("EasyDrive.sqlite3")
    cur = con.cursor()

    try:
        cur.execute("""
            INSERT INTO Customers (name, address, pps_number, driving_license, registration_number)
            VALUES (?, ?, ?, ?, ?)
        """, (data["name"], data["address"], data["pps_number"], data["driving_license"], reg_no))

        print("\nRecord is inserted....")
        con.commit()
        print("Data is saved......")

    except sqlite3.DatabaseError as e:
        print("This is a database error, cannot store the data...")
        print(e)
        con.rollback()

    except Exception as e:
        print("Error:", e)
        con.rollback()

    finally:
        cur.close()
        con.close()


def show_records():
    con = sqlite3.connect("EasyDrive.sqlite3")
    cur = con.cursor()

    try:
        cur.execute("select * from Customers")
        print("\nThe records are as follows: ")
        for record in cur:
            print(record)

    except Exception as e:
        print("Error while showing records:", e)

    finally:
        cur.close()
        con.close()


def TCP_server():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    host = '127.0.0.1'
    port = 9999

    try:
        sock.bind((host, port))
        print("\nServer is ready....")

        sock.listen()
        print("Server is listening for connection...")

        con, addr = sock.accept()
        print(f"Server is connected to {addr}")

        msg = con.recv(4096)
        customer_data = json.loads(msg.decode())

        print("\nCustomer details received from client:")
        print(customer_data)

        reg_no = generate_registration_number()
        insert_customer(customer_data, reg_no)

        response = "Registration successful. Your registration number is: " + reg_no
        con.sendall(response.encode())

        show_records()

        con.close()

    except TimeoutError:
        print("Time out error...")

    except OSError as e:
        print("OS Error....")
        print(e)

    except KeyboardInterrupt:
        print("Process is killed.....")

    except Exception as e:
        print("Error:", e)

    finally:
        sock.close()


def main():
    print("------ EasyDrive TCP Server ------")
    create_database()
    TCP_server()


if __name__ == "__main__":
    main()