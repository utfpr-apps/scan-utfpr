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
import LayoutNotificationsTableActionsHandleStatus from "./LayoutNotificationsTableActionsHandleStatus";

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
      <MenuDivider />
      <LayoutNotificationsTableActionsRemoveNotification
        notification={notification}
      />
      <LayoutNotificationsTableActionsHandleStatus
        notification={notification}
      />
    </MenuList>
  </Menu>
);

export default LayoutNotificationsTableActions;
