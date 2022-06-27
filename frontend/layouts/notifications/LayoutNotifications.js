import Container from "components/Container";
import MainLayout from "components/MainLayout";
import PageLayout from "components/PageLayout";

import LayoutNotificationsHeader from "./LayoutNotificationsHeader";
import LayoutNotificationsTable from "./LayoutNotificationsTable";

const LayoutNotifications = () => (
  <MainLayout>
    <PageLayout pageTitle="Notificações">
      <Container my="25px" direction="column" flex={1} p="32px">
        <LayoutNotificationsHeader />

        <LayoutNotificationsTable />
      </Container>
    </PageLayout>
  </MainLayout>
);

export default LayoutNotifications;
