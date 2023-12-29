namespace Tmds.Linux
{
    public unsafe struct stat
    {
        public dev_t st_dev;

        
        #pragma warning disable CS0169
        private int __st_dev_padding;
        #pragma warning restore CS0169

        #pragma warning disable CS0169
        private int __st_ino_truncated;
        #pragma warning restore CS0169
        
        public mode_t st_mode;
        public nlink_t st_nlink;
        public uid_t st_uid;
        public gid_t st_gid;
        public dev_t st_rdev;

        #pragma warning disable CS0169
        private int __st_rdev_padding;
        
        #pragma warning restore CS0169

        public off_t st_size;
        public blksize_t st_blksize;
        public blkcnt_t st_blocks;
        public timespec st_atim;
        public timespec st_mtim;
        public timespec st_ctim;
        public ino_t st_ino;
    }
}