import { render, screen, fireEvent, waitFor } from "@testing-library/react";

import { act } from "react-dom/test-utils";

import { mockGroupService } from "../../mocks/services/GroupService";
import ListGroupPage from "./ListGroupPage";

jest.mock("react-toastify", () => ({
  ...jest.requireActual("react-toastify"),
  toast: {
    error: jest.fn(),
  },
}));

jest.mock("../../contexts/AuthContext", () => ({
  useAuth: jest.fn(),
}));

jest.mock("../../services/GroupService", () => ({
  __esModule: true,
  default: mockGroupService,
}));

let mockRestrictedNavigate = jest.fn();

describe("ListGroupPage Component", () => {
  beforeEach(() => {
    mockRestrictedNavigate = jest.fn();

    jest
      .spyOn(require("../../contexts/AuthContext"), "useAuth")
      .mockReturnValue({ restrictedNavigate: mockRestrictedNavigate });
  });

  test("should render correctly with empty data", async () => {
    // Arrange
    mockGroupService.paged.mockResolvedValue({
      data: [],
      totalPages: 0,
      totalItems: 0,
      currentPage: 1,
    });

    // Render
    await act(async () => {
      render(<ListGroupPage />);
    });

    // Assert
    await waitFor(() => {
      expect(screen.getByTestId("page-title")).toBeInTheDocument();
      expect(screen.getByTestId("page-description")).toBeInTheDocument();
      expect(screen.getByTestId("empty-group-list")).toBeInTheDocument();
    });
  });

  test("should render correctly with data", async () => {
    // Arrange
    mockGroupService.paged.mockResolvedValue({
      data: [
        {
          id: "1",
          name: "Group 1",
          totalMembers: 5,
          image: "image1.jpg",
          members: [],
        },
      ],
      totalPages: 1,
      totalItems: 1,
      currentPage: 1,
    });

    // Render
    await act(async () => {
      render(<ListGroupPage />);
    });

    // Assert
    await waitFor(() => {
      expect(screen.getByTestId("page-title")).toBeInTheDocument();
      expect(screen.getByTestId("page-description")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-1")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-image-1")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-name-1")).toBeInTheDocument();
      expect(
        screen.getByTestId("group-item-total-members-1"),
      ).toBeInTheDocument();
    });
  });

  test("should toast error when service throw exception", async () => {
    // Arrange
    mockGroupService.paged.mockRejectedValue(new Error("error"));

    // Render
    await act(async () => {
      render(<ListGroupPage />);
    });

    // Assert
    await waitFor(() => {
      expect(require("react-toastify").toast.error).toHaveBeenCalledTimes(1);
      expect(require("react-toastify").toast.error).toHaveBeenCalledWith(
        "error",
      );
    });
  });

  test("should navigates to view-group page on button click", async () => {
    // Arrange
    mockGroupService.paged.mockResolvedValue({
      data: [
        {
          id: "1",
          name: "Group 1",
          totalMembers: 5,
          image: "image1.jpg",
          members: [],
        },
      ],
      totalPages: 1,
      totalItems: 1,
      currentPage: 1,
    });

    // Render
    await act(async () => {
      render(<ListGroupPage />);
    });

    // Assert
    await waitFor(() => {
      expect(screen.getByTestId("group-item-1")).toBeInTheDocument();
    });

    const groupButton = screen.getByTestId("group-item-1");
    fireEvent.click(groupButton);

    // Assert
    expect(mockRestrictedNavigate).toHaveBeenCalledTimes(1);
    expect(mockRestrictedNavigate).toHaveBeenCalledWith("/view-group/1");
  });

  test("should handle pagination correctly", async () => {
    // Arrange
    mockGroupService.paged.mockResolvedValue({
      data: [
        {
          id: "1",
          name: "Group 1",
          totalMembers: 1,
          image: "image1.jpg",
          members: [],
        },
        {
          id: "2",
          name: "Group 2",
          totalMembers: 2,
          image: "image2.jpg",
          members: [],
        },
        {
          id: "3",
          name: "Group 3",
          totalMembers: 3,
          image: "image3.jpg",
          members: [],
        },
        {
          id: "4",
          name: "Group 4",
          totalMembers: 4,
          image: "image4.jpg",
          members: [],
        },
        { id: "5", name: "Group 5", totalMembers: 5, image: "", members: [] },
      ],
      totalPages: 2,
      totalItems: 5,
      currentPage: 1,
    });

    // Render
    await act(async () => {
      render(<ListGroupPage />);
    });

    // Assert
    await waitFor(() => {
      expect(screen.getByTestId("group-item-1")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-2")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-3")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-4")).toBeInTheDocument();
    });

    await act(async () => {
      fireEvent.click(screen.getByTestId("next-page"));
    });

    await waitFor(() => {
      expect(screen.getByTestId("group-item-5")).toBeInTheDocument();
    });

    await act(async () => {
      fireEvent.click(screen.getByTestId("previus-page"));
    });

    await waitFor(() => {
      expect(screen.getByTestId("group-item-1")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-2")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-3")).toBeInTheDocument();
      expect(screen.getByTestId("group-item-4")).toBeInTheDocument();
    });
  });
});
