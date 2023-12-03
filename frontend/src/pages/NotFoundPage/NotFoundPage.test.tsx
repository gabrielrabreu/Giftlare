import { render, screen, fireEvent } from "@testing-library/react";

import React from "react";

import NotFoundPage from "./NotFoundPage";

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: () => jest.fn(),
}));

describe("NotFoundPage Componente", () => {
  test("renders NotFoundPage correctly", () => {
    // Render
    render(<NotFoundPage />);

    // Assert
    expect(screen.getByTestId("error-code")).toBeInTheDocument();
    expect(screen.getByTestId("error-message")).toBeInTheDocument();
    expect(screen.getByTestId("error-detail")).toBeInTheDocument();
    expect(screen.getByTestId("redirect-button")).toBeInTheDocument();
  });

  test("navigates to home page on button click", () => {
    // Arrange
    const mockNavigate = jest.fn();
    jest
      .spyOn(require("react-router-dom"), "useNavigate")
      .mockReturnValue(mockNavigate);

    // Render
    render(<NotFoundPage />);

    // Act
    const redirectButton = screen.getByTestId("redirect-button");
    fireEvent.click(redirectButton);

    // Assert
    expect(mockNavigate).toHaveBeenCalledWith("/");
  });
});
