import { useRef } from "react";
import ProductCard from "./ProductCard";

function ComponentCarousel({ itemArray }) {
    const carouselRef = useRef(null);

    const smoothScrollBy = (distance, duration = 300) => {
        if (!carouselRef.current) return;

        const start = carouselRef.current.scrollLeft;
        const startTime = performance.now();

        const step = (currentTime) => {
            const elapsed = currentTime - startTime;
            const progress = Math.min(elapsed / duration, 1);
            carouselRef.current.scrollLeft =
                start + distance * easeInOutQuad(progress);

            if (progress < 1) {
                requestAnimationFrame(step);
            }
        };

        const easeInOutQuad = (t) =>
            t < 0.5 ? 2 * t * t : -1 + (4 - 2 * t) * t;

        requestAnimationFrame(step);
    };

    const scrollLeft = () => {
        smoothScrollBy(-300, 350); 
    };

    const scrollRight = () => {
        smoothScrollBy(300, 350);
    };

    // Drag-to-scroll logic
    let isDown = false;
    let startX;
    let scrollLeftStart;

    const handleMouseDown = (e) => {
        isDown = true;
        startX = e.pageX - carouselRef.current.offsetLeft;
        scrollLeftStart = carouselRef.current.scrollLeft;
        carouselRef.current.classList.add("cursor-grabbing", "dragging");
    };

    const handleMouseLeave = () => {
        isDown = false;
        carouselRef.current.classList.remove("cursor-grabbing", "dragging");
    };

    const handleMouseUp = () => {
        isDown = false;
        carouselRef.current.classList.remove("cursor-grabbing", "dragging");
    };

    const handleMouseMove = (e) => {
        if (!isDown) return;
        e.preventDefault();
        const x = e.pageX - carouselRef.current.offsetLeft;
        const walk = (x - startX) * 1.5;
        carouselRef.current.scrollLeft = scrollLeftStart - walk;
    };

    return (
        <div className="relative w-full bg-gray-50 border-y border-gray-200">
            
            {/* Left Button */}
            <button
                onClick={scrollLeft}
                className="absolute left-0 top-0 h-full w-16 
                        flex items-center justify-center
                        bg-gradient-to-r from-white via-white/80 to-transparent
                        hover:via-white/90 hover:from-white/95
                        transition-all duration-200 ease-in-out
                        group"
            >
                <span className="text-gray-700 text-2xl font-bold 
                                group-hover:scale-110 transition-transform duration-200">
                    ◀
                </span>
            </button>

            {/* Scrollable Section */}
            <div
                ref={carouselRef}
                className="flex gap-6 overflow-x-auto px-10 no-scrollbar cursor-grab py-6 select-none"
                onMouseDown={handleMouseDown}
                onMouseLeave={handleMouseLeave}
                onMouseUp={handleMouseUp}
                onMouseMove={handleMouseMove}
            >
                {itemArray.map((item, index) => (
                    <ProductCard
                        key={index}
                        item={item}
                    />
                ))}
            </div>

            {/* Right Button */}
            <button
                onClick={scrollRight}
                className="absolute right-0 top-0 h-full w-16 
                        flex items-center justify-center
                        bg-gradient-to-l from-white via-white/80 to-transparent
                        hover:via-white/90 hover:from-white/95
                        transition-all duration-200 ease-in-out
                        group"
            >
                <span className="text-gray-700 text-2xl font-bold 
                                group-hover:scale-110 transition-transform duration-200">
                    ▶
                </span>
            </button>

        </div>
    );
}

export default ComponentCarousel;
