import { useEffect } from "react";
import {
  Navbar,
  HeroSection,
  FeaturesSection,
  CourtsSection,
  TestimonialsSection,
  HowItWorks,
  AppMockup,
  CTASection,
} from "../components";

// Main HomePage Component
export const HomePage = () => {
  useEffect(() => {
    const reveal = () => {
      const reveals = document.querySelectorAll(".reveal-section");
      reveals.forEach((element) => {
        const windowHeight = window.innerHeight;
        const elementTop = element.getBoundingClientRect().top;
        const elementVisible = 150;
        if (elementTop < windowHeight - elementVisible) {
          element.classList.add("active");
        }
      });
    };

    window.addEventListener("scroll", reveal);
    // Initial check
    reveal();
    
    return () => window.removeEventListener("scroll", reveal);
  }, []);

  return (
    <div className="min-h-screen">
      <Navbar />
      <div className="reveal-section"><HeroSection /></div>
      <div className="reveal-section reveal"><FeaturesSection /></div>
      <div className="reveal-section reveal"><CourtsSection /></div>
      <div className="reveal-section reveal"><TestimonialsSection /></div>
      <div className="reveal-section reveal"><HowItWorks /></div>
      <div className="reveal-section reveal"><AppMockup /></div>
      <div className="reveal-section reveal"><CTASection /></div>
    </div>
  );
};

export default HomePage;
