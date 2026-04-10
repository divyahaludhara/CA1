# EasyDrive Client
# Collects customer information
# Sends the data to server using TCP
# Receives registration number from server

import socket
import json

def TCP_client():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    host = '127.0.0.1'
    port = 9999

    try:
        sock.connect((host, port))
        print("Client is connected to server....")

        print("\n------ EasyDrive Customer Registration ------")
        name = input("Enter Name: ")
        address = input("Enter Address: ")
        pps_number = input("Enter PPS Number: ")
        driving_license = input("Enter Driving License document: ")

        customer = {
            "name": name,
            "address": address,
            "pps_number": pps_number,
            "driving_license": driving_license
        }

        message = json.dumps(customer)
        sock.sendall(message.encode())
        print("\nCustomer details sent to server....")

        response = sock.recv(1024)
        print("\nServer:", response.decode())

    except ConnectionRefusedError:
        print("Server is not running....")

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
    print("------ EasyDrive TCP Client ------")
    TCP_client()


if __name__ == "__main__":
    main()