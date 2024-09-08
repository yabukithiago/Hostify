import { useState, useEffect } from 'react';
import { Input } from "../Button/Input";
import { Button } from "../Button/Button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "../Card/Card";
import { MapPinIcon, BedDoubleIcon, SearchIcon, MenuIcon } from "lucide-react";

export default function HomePage() {
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
  const [featuredRooms, setFeaturedRooms] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchRooms() {
      try {
        const response = await fetch('https://localhost:7244/api/Quartos');
        const data = await response.json();
        setFeaturedRooms(data);
      } catch (error) {
        console.error('Error fetching rooms:', error);
      } finally {
        setLoading(false);
      }
    }

    fetchRooms();
  }, []);

  if (loading) {
    return <div className="flex justify-center items-center h-screen">Loading...</div>;
  }

  return (
    <div className="flex flex-col min-h-screen">
      <header className="bg-white shadow-sm">
        <div className="container mx-auto px-4 py-4 flex items-center justify-between">
          <div className="flex items-center">
            <BedDoubleIcon className="h-8 w-8 text-primary mr-2" />
            <span className="text-xl font-bold">Hostify</span>
          </div>
          <nav className="hidden md:flex space-x-4">
            <a href="/" className="text-gray-600 hover:text-gray-900">Home</a>
            {/* <a href="#" className="text-gray-600 hover:text-gray-900">Rooms</a>
            <a href="#" className="text-gray-600 hover:text-gray-900">About</a>
            <a href="#" className="text-gray-600 hover:text-gray-900">Contact</a> */}
          </nav>
          <Button variant="outline" className="md:hidden" onClick={() => setMobileMenuOpen(!mobileMenuOpen)}>
            <MenuIcon className="h-6 w-6" />
          </Button>
        </div>
        {mobileMenuOpen && (
          <nav className="md:hidden bg-white px-4 pt-2 pb-4 space-y-2">
            <a href="/" className="block text-gray-600 hover:text-gray-900">Home</a>
            {/* <a href="#" className="block text-gray-600 hover:text-gray-900">Rooms</a>
            <a href="#" className="block text-gray-600 hover:text-gray-900">About</a>
            <a href="#" className="block text-gray-600 hover:text-gray-900">Contact</a> */}
          </nav>
        )}
      </header>

      <main className="flex-grow">
        <section className="bg-gray-100 py-12 md:py-24">
          <div className="container mx-auto px-4">
            <h1 className="text-4xl md:text-5xl font-bold text-center mb-6">Find Your Perfect Room</h1>
            <p className="text-xl text-center text-gray-600 mb-8">Discover comfortable and affordable rooms for rent in top destinations.</p>
            <div className="max-w-3xl mx-auto">
              <div className="flex flex-col md:flex-row gap-4">
                <Input type="text" placeholder="Where are you going?" className="flex-grow" />
                <Button className="w-full md:w-auto">
                  <SearchIcon className="h-4 w-4 mr-2" />
                  Search Rooms
                </Button>
              </div>
            </div>
          </div>
        </section>

        <section className="py-12">
          <div className="container mx-auto px-4">
            <h2 className="text-3xl font-bold text-center mb-8">Featured Rooms</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {featuredRooms.map((room) => (
                <Card key={room.id}>
                  <CardHeader className="p-0">
                    <img src={room.image} alt={room.title} className="w-full h-48 object-cover" />
                  </CardHeader>
                  <CardContent className="p-4">
                    <CardTitle>{room.title}</CardTitle>
                    <p className="text-gray-600 flex items-center mt-2">
                      <MapPinIcon className="h-4 w-4 mr-1" />
                      {room.location}
                    </p>
                  </CardContent>
                  <CardFooter className="p-4 flex items-center justify-between">
                    <span className="text-lg font-bold">${room.price}/night</span>
                    <Button variant="outline">View Details</Button>
                  </CardFooter>
                </Card>
              ))}
            </div>
          </div>
        </section>
      </main>
    </div>
  );
}
