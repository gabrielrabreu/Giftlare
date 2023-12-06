import { render, screen, fireEvent } from "@testing-library/react";

import HomePage from "./HomePage";

jest.mock("../../contexts/AuthContext", () => ({
  ...jest.requireActual("../../contexts/AuthContext"),
  useAuth: () => jest.fn(),
}));

let mockRestrictedNavigate = jest.fn();

describe("HomePage Componente", () => {
  beforeEach(() => {
    mockRestrictedNavigate = jest.fn();

    jest
      .spyOn(require("../../contexts/AuthContext"), "useAuth")
      .mockReturnValue({ restrictedNavigate: mockRestrictedNavigate });
  });

  test("renders HomePage correctly", () => {
    // Render
    render(<HomePage />);

    // Assert
    expect(screen.getByTestId("first-section-title")).toBeInTheDocument();
    expect(screen.getByTestId("first-section-description")).toBeInTheDocument();
    expect(screen.getByTestId("first-section-button")).toBeInTheDocument();
    expect(screen.getByTestId("first-section-button-text")).toBeInTheDocument();
    expect(screen.getByTestId("second-section-title")).toBeInTheDocument();
    expect(
      screen.getByTestId("second-section-description"),
    ).toBeInTheDocument();
    expect(screen.getByTestId("second-section-button")).toBeInTheDocument();
    expect(
      screen.getByTestId("second-section-button-text"),
    ).toBeInTheDocument();
  });

  test("navigates to list group page on button click", () => {
    // Render
    render(<HomePage />);

    // Act
    const redirectButton = screen.getByTestId("first-section-button");
    fireEvent.click(redirectButton);

    // Assert
    expect(mockRestrictedNavigate).toHaveBeenCalledWith("/list-groups");
  });

  test("navigates to create group page on button click", () => {
    // Render
    render(<HomePage />);

    // Act
    const redirectButton = screen.getByTestId("second-section-button");
    fireEvent.click(redirectButton);

    // Assert
    expect(mockRestrictedNavigate).toHaveBeenCalledWith("/create-group");
  });
});
