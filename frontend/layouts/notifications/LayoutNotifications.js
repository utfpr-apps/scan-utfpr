import Container from "components/Container";
import PageLayout from "components/PageLayout";

import LayoutNotificationsHeader from "./LayoutNotificationsHeader";
import LayoutNotificationsTable from "./LayoutNotificationsTable";

const LayoutNotifications = () => (
  <PageLayout pageTitle="Notificações">
    <Container my="25px" direction="column" flex={1} p="32px">
      <LayoutNotificationsHeader />

      <LayoutNotificationsTable />
    </Container>
  </PageLayout>
);

export default LayoutNotifications;
