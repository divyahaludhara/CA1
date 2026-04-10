# Web scraping + CSV file operations 

import csv
import requests
from bs4 import BeautifulSoup

# SCRAPE FUNCTION 
def scrape_data(fname):
    url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"

    try:
        response = requests.get(url)
        soup = BeautifulSoup(response.text, "html.parser")

        books = soup.find_all("article", class_="product_pod")

        with open(fname, 'w', newline='', encoding="utf-8") as fhand:
            writer = csv.writer(fhand)
            writer.writerow(["Book Name", "Rating", "Price"])

            for book in books:
                name = book.h3.a["title"]
                price = book.find("p", class_="price_color").text
                rating = book.find("p", class_="star-rating")["class"][1]

                writer.writerow([name, rating, price])

        print("Data scraped and saved into CSV file....")

    except Exception as e:
        print("Error while scraping:", e)


# READ CSV FUNCTION
def file_operations(fname):
    try:
        with open(fname,'r') as fhand:
            reader = csv.reader(fhand, delimiter=",")
            for row in reader:
                print(row)

    except FileNotFoundError:
        print("File not found .... /n Program is terminating .....")

    except csv.Error as err:
        print("CSV error: ",err)

    finally:
        pass


#  MAIN FUNCTION
def main():
    print("\n This code demonstrates web scraping + CSV operations \n")

    fname = "books.csv"

    # Step 1: Scrape data from URL and store in CSV
    scrape_data(fname)

    # Step 2: Read CSV file
    file_operations(fname)


# ENTRY
if __name__ == "__main__":
    main()