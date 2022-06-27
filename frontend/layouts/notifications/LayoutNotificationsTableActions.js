import {
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  MenuDivider,
  IconButton,
} from "@chakra-ui/react";

import { BiDotsVerticalRounded } from "react-icons/bi";

import LayoutNotificationsTableActionsStudents from "./LayoutNotificationsTableActionsStudents";
import LayoutNotificationsTableActionsRemoveNotification from "./LayoutNotificationsTableActionsRemoveNotification";

const LayoutNotificationsTableActions = ({ notification }) => (
  <Menu>
    <MenuButton
      as={IconButton}
      aria-label="Options"
      icon={<BiDotsVerticalRounded />}
      variant="ghost"
    />

    <MenuList>
      <LayoutNotificationsTableActionsStudents notification={notification} />
      <LayoutNotificationsTableActionsRemoveNotification
        notification={notification}
      />
    </MenuList>
  </Menu>
);

export default LayoutNotificationsTableActions;
