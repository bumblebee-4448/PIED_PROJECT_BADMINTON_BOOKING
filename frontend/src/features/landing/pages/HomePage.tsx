import React from "react";
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
  return (
    <div className="min-h-screen">
      <Navbar />
      <HeroSection />
      <FeaturesSection />
      <CourtsSection />
      <TestimonialsSection />
      <HowItWorks />
      <AppMockup />
      <CTASection />
    </div>
  );
};

export default HomePage;
